using DadtApi;
using DadtApi.CommonUtility;
using DadtApi.Configuration;
using DadtApi.Context;
using DadtApi.DomainModels;
using DadtApi.IServices;
using DadtApi.Providers;
using DadtApi.Services;
using IAPServices.CommonUtility;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var env = builder.Environment;

////Reuse the start up file
//// Manually create an instance of the Startup class
//var startup = new Startup(builder.Environment);

//// Manually call ConfigureServices()
//startup.ConfigureServices(builder.Services);

//var app = builder.Build();

//// Call Configure(), passing in the dependencies
//startup.Configure(app, app.Environment);

//app.Run();

//Incorporate startup.cs file with program.cs
builder.Configuration
.SetBasePath(env.ContentRootPath)
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
.AddEnvironmentVariables();

builder.Services.AddAuthentication(sharedOptions =>
{
    sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Audience = builder.Configuration.GetValue<string>("AzureAd:Audience");
    options.Authority = builder.Configuration.GetValue<string>("AzureAd:Instance") +
    builder.Configuration.GetValue<string>("AzureAd:Tenant");

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration.GetValue<string>("AzureAd:Issuer"),
        ValidAudience = builder.Configuration.GetValue<string>("AzureAd:Audience")
    };
});

builder.Services.Configure<AzureAdOptions>(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IIdentityService, AzureAdIdentityService>();
builder.Services.AddScoped<IAuthenticationProvider, OnBehalfOfMsGraphAuthenticationProvider>();
builder.Services.AddScoped<IGraphApiService, GraphApiService>();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000");
        });
});

// Register Controllers
builder.Services.AddControllers();

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register the Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});
// Register Entity Framework
builder.Services.AddDbContext<dbContext>(options => options.UseNpgsql(EncryptionHelper.Decrypt(builder.Configuration["ConnectionStrings:DADTConnection"])));

//Register Interface to Class Mapping
builder.Services.AddTransient<IAttributeMetaDataService, AttributeMetaDataService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUsers, Users>();
builder.Services.AddTransient<ILog, Log>();
builder.Services.AddTransient<IDepartmentSearchService, DepartmentSearchService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IUrlCheck, UrlCheck>();
builder.Services.AddTransient<IWebObjectMetadataService, WebObjectMetadataService>();
builder.Services.AddTransient<IDepartmentsService, DepartmentsService>();
builder.Services.AddTransient<IActiveDirectoryService, ActiveDirectoryService>();
builder.Services.AddTransient<IIapmSolutionService, IapmSolutionService>();

//CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

//Odata
builder.Services.AddOData();

//Changing JSON response to Pascal case from default CamelCase for Apigee
var apiType = Environment.GetEnvironmentVariable("API_TYPE");
if (apiType != null && apiType.Equals("Apigee", StringComparison.CurrentCultureIgnoreCase))
{
    builder.Services.AddMvc().AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());
}

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers(mvcOptions =>
    mvcOptions.EnableEndpointRouting = false).AddXmlSerializerFormatters();
builder.Services.AddMvc(options =>
{
    foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
    {
        outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
    }

    foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
    {
        inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
    }
});

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(365);
});

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseAuthentication();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable swagger
if (!env.IsProduction())
{
    // Register the Swagger generator and the Swagger UI middlewares
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "/swagger/" + "v1" + "/swagger.json";
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.None,
};
app.UseCookiePolicy();
app.UseHsts();
app.UseMvc(routeBuilder =>
{
    routeBuilder.EnableDependencyInjection();
    routeBuilder.Expand().Select().Filter().Count().OrderBy().MaxTop(100).SkipToken();
});
app.Run();