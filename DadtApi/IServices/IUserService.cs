using DadtApi.DomainModels;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IUserService
    {
        Task<User> GetUserByWwid(string Wwid);
    }
}
