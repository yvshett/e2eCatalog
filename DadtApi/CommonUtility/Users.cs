using DadtApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IAPServices.CommonUtility
{
    public class CurrentUserInfo
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public bool IsAuthenticated { get; set; }
    }
    public class UsersSearch
    {
        public string Wwid { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class ActiveDirectoryGroupSearch
    {
        public string Id { get; set; }
        public string DisplayNm { get; set; }
    }
    public interface IUsers
    {
        public CurrentUserInfo CurrentUser();
        public Task<string> GetCurrentUserWwid();
        public Task<string> CheckAdmin();
        public Task<string> CheckMemberGroupsAsync(IEnumerable<string> groupIds);
        public Task<IEnumerable<UsersSearch>> Search(string term, int? resultSize);
        public Task<IEnumerable<ActiveDirectoryGroupSearch>> SearchGroups(string term, int? resultSize);
    }
    public class Users:IUsers
    {
        private readonly IIdentityService _identityService;
        private readonly IGraphApiService _graphApiService;
        public IConfiguration _configuration { get; }

        public Users(IIdentityService identityService, IGraphApiService graphApiService, IConfiguration configuration)
        {
            _identityService = identityService;
            _graphApiService = graphApiService;
            _configuration = configuration;
        }

        public CurrentUserInfo CurrentUser()
        {
            return new CurrentUserInfo
            {
                Id = _identityService.GetId(),
                Login = _identityService.GetMail(),
                IsAuthenticated = _identityService.IsAuthenticated()
            };
        }

        public async Task<string> GetCurrentUserWwid()
        {
            try
            {
                var result = await _graphApiService.GetUserProfileAsync();
                return result.JobTitle.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CheckMemberGroupsAsync(IEnumerable<string> groupIds)
        {
            try
            {
                var result = await _graphApiService.CheckMemberGroupsAsync(groupIds);
                if (result.Count() > 0)
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
            }
            catch (Exception)
            {
                return "N";
            }
        }

        public async Task<string> CheckAdmin()
        {
            try
            {
                var roleGroups = new Dictionary<string, string>();
                _configuration.Bind("DADTAdminGroups", roleGroups);

                var result = await _graphApiService.CheckMemberGroupsAsync(roleGroups.Keys);
                if (result.Count() > 0)
                {
                    return "Y";
                }
                else
                {
                    return "N";
                }
            }
            catch (Exception)
            {
                return "N";
            }
        }

        public async Task<IEnumerable<UsersSearch>> Search(string term, int? resultSize)
        {
            List<UsersSearch> users = new List<UsersSearch>();
            var userList= await _graphApiService.SearchUsersAsync(term, (int)resultSize);
            foreach (var user in userList)
            {
                users.Add(new UsersSearch { Wwid = user.JobTitle, Name = user.GivenName, DisplayName = user.DisplayName });
            }
            return users;
        }

        public async Task<IEnumerable<ActiveDirectoryGroupSearch>> SearchGroups(string term, int? resultSize)
        {
            List<ActiveDirectoryGroupSearch> groups = new List<ActiveDirectoryGroupSearch>();
            var groupList = await _graphApiService.SearchGroupsAsync(term, (int)resultSize);
            foreach (var group in groupList)
            {
                groups.Add(new ActiveDirectoryGroupSearch { Id = group.Id, DisplayNm = group.DisplayName });
            }
            return groups;
        }
    }
}