using DadtApi.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DadtApi.DomainModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerSearchController : ControllerBase
    {
        private readonly IWorkerSearchService _workerSearchService;
        private readonly ILogger<WorkerSearchController> _logger;

        public WorkerSearchController(ILogger<WorkerSearchController> logger, IWorkerSearchService workerSearchService)
        {
            _logger = logger;
            _workerSearchService = workerSearchService;
        }

        // GET api/<WorkerSearchController>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerSearch>>> Get(string search, int? resultSize = 10)
        {
            try
            {
                return await _workerSearchService.GetData(search, resultSize);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in WorkerSearchController: {ex.Message}");
                return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
            }
        }
    }
}
