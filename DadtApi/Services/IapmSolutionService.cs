using DadtApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadtApi.IServices;
using Microsoft.EntityFrameworkCore;
using DadtApi.DomainModels;
using DadtApi.CommonUtility;

namespace DadtApi.Services
{
    public class IapmSolutionService : IIapmSolutionService
    {
        private readonly dbContext _context;

        List<string> appActiveStatuses = new List<string>() { "Planning","Being Assembled", "Deployed", "Deployed-Legal Hold"};

        public IapmSolutionService(dbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to return all solution details
        /// </summary>
        /// <param name="wwid"></param>
        /// <param name="adminInd"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetAllSolutions(string wwid, string adminInd, string includeInactive)
        {
            try
            {

            return await _context.IapmApplications
                .Where(a => includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Method to return wwid which associated in solutions
        /// </summary>
        /// <param name="Wwid"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsAssociatedByWwid(string wwid, string includeInactive)
        {
            return await _context.IapmApplications
                .Where(a => a.ProductOwnerWwid == wwid
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();
        }

        /// <summary>
        /// Method to return solutions by Product Owner wwid
        /// </summary>
        /// <param name="Wwid"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsByProductOwner(string wwid, string includeInactive)
        {
            List<string> fieldNm = new List<string>() { "App Lifecycle Status", "Lifecycle Status", "Legal Hold" };
            return await _context.IapmApplications
                .Where(a => a.ProductOwnerWwid == wwid
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();
        }

        /// <summary>
        /// Method to return Solutions by Organization
        /// </summary>
        /// <param name="Wwid"></param>
        /// <param name="adminInd"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsByOrganization(string wwid, string adminInd, string includeInactive)
        {
            string currentUserDepartmentCd = _context.Workers.Where(u => u.Wwid == wwid).Select(w => w.DepartmentCd).FirstOrDefault();
            return await _context.IapmApplications
                .Where(a => a.ApplicationOwningDepartmentCd == currentUserDepartmentCd
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();
        }

        /// <summary>
        /// Method to return Solutions by Organization Level3
        /// </summary>
        /// <param name="wwid"></param>
        /// <param name="adminInd"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsByOrgLevel3(string wwid, string adminInd, string includeInactive)
        {
            string currentUserOrgLevel3Cd = _context.Departments
                .Where(d => d.DepartmentCd == _context.Workers.Where(w => w.Wwid == wwid).Select(w => w.DepartmentCd).FirstOrDefault())
                .Select(d => d.DepartmentLevel3Cd).FirstOrDefault();

            List<int> filteredAppIds = await _context.IapmApplications
                .Join(
                    _context.Departments,
                    app => app.ApplicationOwningDepartmentCd,
                    dept => dept.DepartmentCd,
                    (app, dept) => new { app, dept }
                ).Where(result => result.dept.DepartmentLevel3Cd == currentUserOrgLevel3Cd)
                .Select(result => result.app.ApplicationId).ToListAsync();

            return await _context.IapmApplications
                .Where(a => filteredAppIds.Contains(a.ApplicationId)
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();
        }

        /// <summary>
        /// Get Solutions by Super Group
        /// </summary>
        /// <param name="wwid"></param>
        /// <param name="adminInd"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsBySuperGroup(string wwid, string adminInd, string includeInactive)
        {
            string currentUserSuperGroup = _context.Workers
                .Where(w => w.Wwid == wwid).Select(w => w.SuperGroupLongNm.ToUpper()).FirstOrDefault();

            return await _context.IapmApplications
                .Where(a =>a.SuperGroupLongNm.ToUpper() == currentUserSuperGroup
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();

        }

        /// <summary>
        /// Method to return IT Solutions
        /// </summary>
        /// <param name="wwid"></param>
        /// <param name="adminInd"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsByIT(string wwid, string adminInd, string includeInactive)
        {

            return await _context.IapmApplications
                .Where(a => a.InformationTechnologyManagedApplicationInd == Constants.CHR_YES
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();
        }

        /// <summary>
        /// Method to return BU Solutions
        /// </summary>
        /// <param name="wwid"></param>
        /// <param name="adminInd"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public async Task<List<AllSolutionsView>> GetSolutionsByBU(string wwid, string adminInd, string includeInactive)
        {
          
            return await _context.IapmApplications
                .Where(a => a.InformationTechnologyManagedApplicationInd != Constants.CHR_YES
                && (includeInactive == Constants.STR_YES || appActiveStatuses.Contains(a.ApplicationLifecycleStatusNm)))
                .Select(a => new AllSolutionsView
                {
                    ApplicationId = a.ApplicationId,
                    ApplicationNm = a.ApplicationNm,
                    ApplicationAcronymNm = a.ApplicationAcronymNm,
                    ApplicationDetailsUrlTxt = a.ApplicationDetailsUrlTxt,
                    InformationDataClassificationNm = a.InformationDataClassificationNm,
                    InformationTechnologySupportTierNm = a.InformationTechnologySupportTierNm,
                    TmModelNm = a.TmModelNm,
                    ProductOwnerNm = a.ProductOwnerNm,
                    ApplicationLifecycleStatusNm = a.ApplicationLifecycleStatusNm,
                    ApplicationClassificationNm = a.ApplicationClassificationNm,
                    SuperGroupLongNm = a.SuperGroupLongNm,
                    GroupLongNm = a.GroupLongNm,
                    DivisionLongNm = a.DivisionLongNm,
                    ApplicationOwningDepartmentNm = a.ApplicationOwningDepartmentNm,
                    ApplicationOwningDepartmentLevel4Nm = a.ApplicationOwningDepartmentLevel4Nm,
                    ApplicationOwningDepartmentLevel3Nm = a.ApplicationOwningDepartmentLevel3Nm,
                    TmModelEndDt = a.TmModelEndDt,
                    ApplicationLifecycleStatusEndDtm = a.ApplicationLifecycleStatusEndDtm,
                    SaasSolutionInd = a.SaasSolutionInd != null ? a.SaasSolutionInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd = a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd != null ? a.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd == Constants.CHR_YES ? "Yes" : "No" : "",
                    BusinessOrganizationNm = a.BusinessOrganizationNm,
                    ApplicationUserBaseNm = a.ApplicationUserBaseNm,
                    PaceLayeringNm = a.PaceLayeringNm,
                    InformationTechnologyServiceNm = a.InformationTechnologyServiceNm,
                    ApplicationHostingTypeNm = a.ApplicationHostingTypeNm,
                    InformationTechnologyManagedApplicationInd = a.InformationTechnologyManagedApplicationInd,
                })
                .OrderByDescending(a => a.ApplicationId).ToListAsync();
        }
    }
}

