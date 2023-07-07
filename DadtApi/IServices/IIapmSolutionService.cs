using DadtApi.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IIapmSolutionService
    {
        Task<List<AllSolutionsView>> GetAllSolutions(string wwid, string adminInd, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsAssociatedByWwid(string Wwid, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsByProductOwner(string Wwid, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsByOrganization(string Wwid, string adminInd, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsByOrgLevel3(string Wwid, string adminInd, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsBySuperGroup(string Wwid, string adminInd, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsByIT(string Wwid, string adminInd, string includeinactive);
        Task<List<AllSolutionsView>> GetSolutionsByBU(string Wwid, string adminInd, string includeinactive);
    }
}
