using DadtApi.CommonUtility;
using Microsoft.AspNetCore.Mvc;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlCheckController : ControllerBase
    {
        private readonly IUrlCheck _urlCheck;

        public UrlCheckController(IUrlCheck urlCheck)
        {
            _urlCheck = urlCheck;
        }

        /// <summary>
        /// check if a URL is valid or not
        /// </summary>
        /// <param name="url"> URL </param>
        /// <returns>
        /// Return 0 for invalid URL and 1 for valid URL " . 
        /// </returns>
        // GET: api/UrlCheck/test.com
        [HttpGet]
        public int GetURLCheck(string url)
        {
            return _urlCheck.ValidateUrl(url);
        }
    }
}
