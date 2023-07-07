using DadtApi.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration _configuration { get; }

        public EnvironmentController(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        // POST api/Environment/
        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                return "ASPNETCORE_ENVIRONMENT: " + _env.EnvironmentName +"; Config File: "+ _configuration["config_file"];
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
