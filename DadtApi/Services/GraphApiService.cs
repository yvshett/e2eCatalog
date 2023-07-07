using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.Services
{
    public interface IGraphApiService
    {
        Task<User> GetUserProfileAsync();
        Task<List<User>> SearchUsersAsync(string search, int limit);
        Task<List<Group>> SearchGroupsAsync(string search, int limit);
        Task<IEnumerable<string>> CheckMemberGroupsAsync(IEnumerable<string> groupIds);
    }

    public class GraphApiService : IGraphApiService
    {
        private readonly IAuthenticationProvider _msGraphAuthenticationProvider;

        public GraphApiService(IAuthenticationProvider authenticationProvider)
        {
            _msGraphAuthenticationProvider = authenticationProvider;
        }

        public async Task<User> GetUserProfileAsync()
        {
            var client = new GraphServiceClient(_msGraphAuthenticationProvider);
            return await client.Me.Request().GetAsync();
        }

        public async Task<IEnumerable<string>> CheckMemberGroupsAsync(IEnumerable<string> groupIds)
        {
            var client = new GraphServiceClient(_msGraphAuthenticationProvider);
            return await client.Me.CheckMemberGroups(groupIds).Request().PostAsync();
        }

        public async Task<List<User>> SearchUsersAsync(string search, int limit)
        {
            var client = new GraphServiceClient(_msGraphAuthenticationProvider);
            var users = new List<User>();

            var currentReferencesPage = await client.Users
                .Request()
                .Top(limit)
                .Filter($"startsWith(displayName, '{search}') or startswith(mail, '{search}')")
                .GetAsync();

            users.AddRange(currentReferencesPage);

            return users;
        }

        public async Task<List<Group>> SearchGroupsAsync(string search, int limit)
        {
            var client = new GraphServiceClient(_msGraphAuthenticationProvider);
            var groups = new List<Group>();

            var currentReferencesPage = await client.Groups
                .Request()
                .Top(limit)
                .Filter($"startsWith(displayName, '{search}') or startswith(mailNickname, '{search}')")
                .GetAsync();

            groups.AddRange(currentReferencesPage);

            return groups;
        }
    }
}
