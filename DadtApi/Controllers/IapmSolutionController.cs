using DadtApi.IServices;
using Microsoft.AspNetCore.Mvc;
using DadtApi.DomainModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using IAPServices.CommonUtility;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IapmSolutionController : ControllerBase
    {
        private readonly IIapmSolutionService _iapmSolutionService;
        private readonly IUsers _userService;

        public IapmSolutionController(IIapmSolutionService allSolutionService, IUsers userService)
        {
            _iapmSolutionService = allSolutionService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllSolutionsView>>> Get()
        {
            //Get logged in User wwid
            var wwid = await _userService.GetCurrentUserWwid();

            //Check Whether logged in user is Admin or not
            string adminInd = await _userService.CheckAdmin();

            return await _iapmSolutionService.GetAllSolutions(wwid, adminInd, CommonUtility.Constants.STR_YES);
        }

        [HttpGet("me")]
        public async Task<ActionResult<IEnumerable<AllSolutionsView>>> GetMyApps()
        {
            //Get logged in User wwid
            var wwid = await _userService.GetCurrentUserWwid();

            return await _iapmSolutionService.GetSolutionsAssociatedByWwid(wwid, CommonUtility.Constants.STR_YES);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<AllSolutionsView>>> GetAppsByFilter(int key,string includeInactive = "N")
        {
            //Get logged in User wwid
            var wwid = await _userService.GetCurrentUserWwid();

            //Check Whether logged in user is Admin or not
            string adminInd = await _userService.CheckAdmin();

            // Filters in All Solutions
            switch (key)
            {
                case 1: return await _iapmSolutionService.GetAllSolutions(wwid, adminInd, includeInactive); // All Solutions
                case 2: return await _iapmSolutionService.GetSolutionsAssociatedByWwid(wwid, includeInactive); //Solutions I'm associated with
                case 3: return await _iapmSolutionService.GetSolutionsByProductOwner(wwid, includeInactive); // Solutions I own
                case 4: return await _iapmSolutionService.GetSolutionsByOrganization(wwid, adminInd, includeInactive);
                case 5: return await _iapmSolutionService.GetSolutionsByOrgLevel3(wwid, adminInd, includeInactive); // Solutions owned by my Organization
                case 6: return await _iapmSolutionService.GetSolutionsBySuperGroup(wwid, adminInd, includeInactive); // Solutions owned by my Super Group
                case 7: return await _iapmSolutionService.GetSolutionsByIT(wwid, adminInd, includeInactive); // IT Solutions
                case 8: return await _iapmSolutionService.GetSolutionsByBU(wwid, adminInd, includeInactive); // Non-IT Solutions
                default: return await _iapmSolutionService.GetAllSolutions(wwid, adminInd, includeInactive);
            }

        }
    }
}
