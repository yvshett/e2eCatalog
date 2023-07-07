using DadtApi.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IWorkerSearchService
    {
        Task<List<WorkerSearch>> GetData(string searchValue, int? resultSize);
        Task<List<WorkerSearch>> GetSelectedData(List<string> selectedwwId);
    }
}
