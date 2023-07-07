using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using IAPServices.CommonUtility;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdGroupSearchController : ControllerBase
    {
        public IConfiguration _configuration { get; }
        private readonly IActiveDirectoryService _activeDirectoryService;

        public AdGroupSearchController(IConfiguration configuration, IActiveDirectoryService activeDirectoryService)
        {
            _configuration = configuration;
            _activeDirectoryService = activeDirectoryService;
        }

        // Get api/AdGroupSearch/
        [HttpGet]
        public IEnumerable<ADGroupSearch> Get(string searchValue, int? resultSize = 10)
        {        
            List<ADGroupSearch> results = new List<ADGroupSearch>();
            Regex regex = new Regex(@"^[a-zA-Z0-9 _-]*$");
            if (regex.IsMatch(searchValue))
            {
                results.AddRange(_activeDirectoryService.SearchADGroups(searchValue, resultSize));
            }
            return results;
        }
    }
}
