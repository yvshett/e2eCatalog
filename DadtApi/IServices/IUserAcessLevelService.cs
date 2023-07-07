using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IUserAcessLevelService
    {
        Task<int> GetUserAccessLevelForSolution(int applicationId, string wwid, string adminInd);
        int GetUserAccessLevelForAssets(int applicationId, string wwid, string adminInd);
    }
}
