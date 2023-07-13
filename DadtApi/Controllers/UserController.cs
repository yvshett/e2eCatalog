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



        // GET api/User/me
        

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
