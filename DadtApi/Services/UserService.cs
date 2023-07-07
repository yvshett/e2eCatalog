using DadtApi.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using DadtApi.IServices;
using Microsoft.EntityFrameworkCore;
using DadtApi.DomainModels;
using DadtApi.CommonUtility;
using System.Reflection;

namespace DadtApi.Services
{
    public class UserService : IUserService
    {
        private readonly dbContext _context;
        private readonly ILog _log;
        public UserService(dbContext context, ILog log)
        {
            _context = context;
            _log = log;
        }

        public async Task<User> GetUserByWwid(string Wwid)
        {
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
            try
            {
                return await _context.Workers.Where(w => w.Wwid == Wwid)
                    .Select(w => new User
                    {
                        Wwid = w.Wwid,
                        FirstNm = w.FirstNm,
                        NickNm = w.NickNm,
                        FullNm = w.FullNm,
                        DepartmentCd = w.DepartmentCd,
                        DepartmentNm = w.DepartmentNm,
                        Idsid = w.Idsid,
                        CorporateEmailTxt = w.CorporateEmailTxt,
                        CcmailNm = w.CcmailNm,
                        WorkLocationBuildingNm = w.WorkLocationBuildingNm,
                        WorkLocationCountryNm = w.WorkLocationCountryNm,
                        WorkLocationSiteNm = w.WorkLocationSiteNm,
                        imageURL = "https://photos.intel.com/images/" + w.Wwid.Trim() + ".jpg",
                        IsITOrg = 1, //(int)_context.VwDepartment.Where(d => d.DepartmentCd == w.DepartmentCd).Select(d => d.IsItOrg).FirstOrDefault(),
                        HumanResourceHierarchy = "",//_context.VwDepartment.Where(d => d.DepartmentCd == w.DepartmentCd).Select(d => d.DepartmentHierarchy).FirstOrDefault(),
                        FinanceHierarchy = w.SuperGroupLongNm + (!String.IsNullOrEmpty(w.GroupLongNm)? " > " + w.GroupLongNm : "") + (!String.IsNullOrEmpty(w.DivisionLongNm)? " > " + w.DivisionLongNm : ""),
                        DepartmentLevel5Cd = null //_context.Department.Where(d => d.DepartmentCd == w.DepartmentCd).Select(d => d.DepartmentLevel5Cd).FirstOrDefault()
                    }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
                return new User();
            }
        }
    }
}
