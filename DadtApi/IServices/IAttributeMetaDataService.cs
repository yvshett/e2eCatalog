using DadtApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IAttributeMetaDataService
    {
        Task<List<WebObjectMetadatum>> Get(string pagenm);
    }
}
