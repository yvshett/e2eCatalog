using DadtApi.Context;
using DadtApi.IServices;
using DadtApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadtApi.Services
{
    public class AttributeMetaDataService : IAttributeMetaDataService
    {
        private readonly dbContext _context;

        public AttributeMetaDataService(dbContext context)
        {
            _context = context;
        }

        public async Task<List<WebObjectMetadatum>> Get(string pagenm)
        {
            return await _context.WebObjectMetadata.Where(o => o.PageNm== pagenm).ToListAsync<WebObjectMetadatum>();
        }
    }
}
