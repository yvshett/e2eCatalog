using DadtApi.DomainModels;
using DadtApi.IServices;
using IAPServices.CommonUtility;
using Microsoft.AspNetCore.Mvc;
using Novell.Directory.Ldap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LdapController : ControllerBase
    {
        private readonly IActiveDirectoryService _activeDirectoryService;

        public LdapController(IActiveDirectoryService activeDirectoryService)
        {
            _activeDirectoryService = activeDirectoryService;

        }
        // GET api/Ldap/GetLdapWorkerSearch/11690382
        [HttpGet("GetLdapWorkerSearch")]
        public async Task<IEnumerable<WorkerSearch>> GetLdapWorkerSearch(string search, int? resultSize = 10)
        {
            return await _activeDirectoryService.GetLdapWorkerSearch(search, resultSize);
        }
    }
}
