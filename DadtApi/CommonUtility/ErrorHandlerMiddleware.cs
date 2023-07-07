using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DadtApi.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DadtApi.CommonUtility
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILog _log;

        public IConfiguration _configuration { get; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// The HttpStatusCode to include in the error response.
        /// </summary>
        public HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

        /// <summary>
        /// An error message to be sent in the description of the error.
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        /// How long of a delay to introduce before the error occurs. Use to simulate timeouts.
        /// </summary>
        public int Delay = 0; //string IapId; string token; string environment; string appName; string org;

        public ErrorHandlerMiddleware(RequestDelegate next, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILog log)
        {
            _next = next;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _log = log;
        }


        private const string DefaultErrorMessage = "Automatic error generated. This is caused by the FailRequest ActionFilter. To stop this error, remove the attribute from the class or method.";


        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env, startTime);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env, string startTime)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = String.Empty;
            /************************ Start CLF Logging *******************************************************/
            var stepnm = _httpContextAccessor.HttpContext.Request.Method + " " + GetAbsoluteUri().ToString();

            //Post logging to CLF
            _log.LogEntry(stepnm, "Error : " + exception, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));

            switch (exception)
            {
                case AppException e:
                    message = exception.Message;
                    status = HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    message = exception.Message;
                    status = HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    status = HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    if (env.IsEnvironment("Development"))
                        stackTrace = exception.StackTrace;
                    break;
            }

            var result = System.Text.Json.JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
            return context.Response.WriteAsync(result);
        }
        
        private Uri GetAbsoluteUri()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Query = request.QueryString.ToString();
            return uriBuilder.Uri;
        }
    }
}
