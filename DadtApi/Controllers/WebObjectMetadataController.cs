using DadtApi.DomainModels;
using DadtApi.IServices;
using IAPServices.CommonUtility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebObjectMetadataController : ControllerBase
    {
        private readonly IWebObjectMetadataService _webObjectService;
        private readonly IUsers _userService;

        public WebObjectMetadataController(IWebObjectMetadataService webObjectService, IUsers userService)
        {
            _webObjectService = webObjectService;
            _userService = userService;
        }

        [HttpGet("GetPageNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetPageNames()
        {
            try
            {
                //Get logged in User wwid
                var wwid = await _userService.GetCurrentUserWwid();

                //Check Whether logged in user is Admin or not
                string adminInd = await _userService.CheckAdmin();

                if(adminInd != CommonUtility.Constants.STR_YES)
                    return Unauthorized();
                
                var pageNames = await _webObjectService.GetPageNames();
                if (pageNames != null)
                    return pageNames;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        [HttpGet("GetWebObjects/{page}")]
        public async Task<ActionResult<IEnumerable<WebObjectView>>> GetWebObjectMetadata(string page)
        {
            Regex regex = new Regex(@"^[a-zA-Z ]*$");
            if (regex.IsMatch(page))
            {
                try
                {
                    //Get logged in User wwid
                    var wwid = await _userService.GetCurrentUserWwid();

                    //Check Whether logged in user is Admin or not
                    string adminInd = await _userService.CheckAdmin();

                    if (adminInd != CommonUtility.Constants.STR_YES)
                        return Unauthorized();

                    var webObjects = await _webObjectService.GetWebObjectMetadata(page);
                    if (webObjects != null)
                        return webObjects;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            return NoContent();
        }

        // PUT api/<WebObjectMetadataController>/5
        [HttpPut]
        public async Task<ActionResult<IEnumerable<WebObjectView>>> PutWebObjectMetadata([Bind] WebObjectView webObjectModel)
        {
            try
            {
                //Get logged in User wwid
                var wwid = await _userService.GetCurrentUserWwid();

                //Check Whether logged in user is Admin or not
                string adminInd = await _userService.CheckAdmin();

                if (adminInd != CommonUtility.Constants.STR_YES)
                    return Unauthorized();

                //Updating Changed by User information
                webObjectModel.ChangeAgentId = wwid;
                webObjectModel.ChangeDtm = DateTime.Now;

                var webObjects = await _webObjectService.UpdateWebObject(webObjectModel);
                if (webObjects == "success")
                    return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NotFound();
        }
    }
}
