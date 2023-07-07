using DadtApi.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using DadtApi.DomainModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using IAPServices.CommonUtility;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUsers _users;
        public IConfiguration _configuration { get; }
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUsers users, IConfiguration configuration,IMapper mapper)
        {
            _userService = userService;
            _users = users;
            _configuration = configuration;
            _mapper = mapper;
        }

        // GET api/User/11611764
        [HttpGet("{wwid}")]
        public async Task<ActionResult<User>> GetUserByWwid(string wwid)
        {
            return await _userService.GetUserByWwid(wwid);
        }

        // GET api/User/me
        [HttpGet("me")]
        public async Task<ActionResult<UserMe>> GetUser()
        {
            try
            {
                UserMe user = new UserMe();
                var wwid = await _users.GetCurrentUserWwid();
                var currentUser = await _userService.GetUserByWwid(wwid);
                user = _mapper.Map<UserMe>(currentUser);

                var roleGroups = new Dictionary<string, string>();
                _configuration.Bind("DADTAdminGroups", roleGroups);

                // check user is in admin group
                user.adminInd = await _users.CheckMemberGroupsAsync(roleGroups.Keys);

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // GET api/User/search/<search text>
        [HttpGet("search/{term}")]
        public async Task<IEnumerable<UsersSearch>> Search(string term, int? resultSize = 10)
        {
            return await _users.Search(term, resultSize);
        }

        // GET api/User/Group/search/<search text>
        [HttpGet("group")]
        public async Task<IEnumerable<ActiveDirectoryGroupSearch>> SearchGroups(string search, int? resultSize = 10)
        {
            return await _users.SearchGroups(search, resultSize);
        }
    }
}
