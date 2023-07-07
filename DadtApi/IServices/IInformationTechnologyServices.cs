using System.Collections.Generic;
using System.Threading.Tasks;
using DadtApi.DomainModels;

namespace DadtApi.IServices
{
    public interface IInformationTechnologyServices
    {
        Task<List<keyvalue>> Get();

        Task<List<keyvalue>> GetItServiceById(int serviceId);
    }
}
