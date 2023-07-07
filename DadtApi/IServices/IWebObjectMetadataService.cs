using DadtApi.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.IServices
{
    public interface IWebObjectMetadataService
    {
        Task<List<WebObjectView>> GetWebObjectMetadata(string page);
        Task<List<string>> GetPageNames();
        Task<string> UpdateWebObject(WebObjectView webObject);
    }
}
