using DadtApi.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IDepartmentSearchService
    {
        Task<List<DepartmentSearch>> GetData(string searchValue, int? resultSize);
        Task<List<DepartmentSearch>> GetSelectedData(List<string> departmentCodeList);
    }
}
