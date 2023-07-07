using DadtApi.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadtApi.IServices;
using Microsoft.EntityFrameworkCore;
using DadtApi.DomainModels;
using System;

namespace DadtApi.Services
{
    public class DepartmentSearchService : IDepartmentSearchService
    {
        private readonly dbContext _context;

        public DepartmentSearchService(dbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentSearch>> GetData(string search, int? resultSize)
        {
            int sizeLimit = (int)resultSize;
            int departmentCd;
            if (int.TryParse(search, out departmentCd))
            {
                return await _context.Departments.Where(d => d.TreeLevelNbr == "4" && d.DepartmentCd.StartsWith(search) && d.ActiveInd == CommonUtility.Constants.CHR_YES)
                    .Select(d => new DepartmentSearch
                    {
                        DepartmentHierarchy = d.DepartmentLevel3Nm + " > " + d.DepartmentLevel4Nm,
                        DepartmentNm = d.DepartmentNm,
                        DepartmentCd = d.DepartmentCd,
                        ActiveInd = d.ActiveInd
                    })
                    .OrderBy(w => w.DepartmentCd).Take(sizeLimit).ToListAsync();
            }
            else
            {
                return await _context.Departments.Where(d => d.TreeLevelNbr == "4" && (d.DepartmentLevel4Nm.StartsWith(search)
                    || d.DepartmentLevel3Nm.Contains(search)) && d.ActiveInd == CommonUtility.Constants.CHR_YES)
                    .Select(d => new DepartmentSearch
                    {
                        DepartmentHierarchy = d.DepartmentLevel3Nm + " > " + d.DepartmentLevel4Nm,
                        DepartmentNm = d.DepartmentNm,
                        DepartmentCd = d.DepartmentCd,
                        ActiveInd = d.ActiveInd
                    }).OrderBy(w => w.DepartmentCd).Take(sizeLimit).ToListAsync();
            }
        }

        public async Task<List<DepartmentSearch>> GetSelectedData(List<string> departmentCodeList)
        {
            return await _context.Departments.Where(d => departmentCodeList.Contains(d.DepartmentCd))
                    .Select(d => new DepartmentSearch
                    {
                        DepartmentHierarchy = d.DepartmentLevel3Nm + " > " + d.DepartmentLevel4Nm,
                        DepartmentNm = d.DepartmentNm,
                        DepartmentCd = d.DepartmentCd,
                        ActiveInd = d.ActiveInd
                    })
                    .OrderBy(w => w.DepartmentCd).ToListAsync();
        }
    }
}
