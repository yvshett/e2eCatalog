using System.Collections.Generic;
using System.Threading.Tasks;
using DadtApi.CommonUtility;
using DadtApi.DomainModels;
using DadtApi.IServices;
using DadtApi.Models;
using DadtApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {

        Ie2eService _e2eService;
        public HomePageController(Ie2eService e2eService)
        {
            _e2eService = e2eService;
        }

        [HttpGet]
        public dynamic GetData()
        {
            return _e2eService.GetCategoriesWithSubcategories();

        }
    }
}




