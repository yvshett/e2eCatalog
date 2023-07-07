using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class IapmApplication
    {
        public int ApplicationId { get; set; }
        public string ApplicationNm { get; set; }
        public string ApplicationAcronymNm { get; set; }
        public string ApplicationClassificationNm { get; set; }
        public char? ApplicationBrowserBasedInd { get; set; }
        public char? ApplicationMobileBasedInd { get; set; }
        public char? ApplicationNativeInd { get; set; }
        public string ApplicationDetailsUrlTxt { get; set; }
        public string ApplicationDsc { get; set; }
        public string ProductOwnerWwid { get; set; }
        public string ProductOwnerEmailtxt { get; set; }
        public string ProductOwnerNm { get; set; }
        public string SuperGroupLongNm { get; set; }
        public string GroupLongNm { get; set; }
        public string DivisionLongNm { get; set; }
        public string ApplicationLifecycleStatusNm { get; set; }
        public DateTime? ApplicationLifecycleStatusEndDtm { get; set; }
        public string ApplicationUserBaseNm { get; set; }
        public string InformationTechnologySupportTierNm { get; set; }
        public int? InformationTechnologySegmentId { get; set; }
        public string InformationTechnologySegmentNm { get; set; }
        public int? InformationTechnologyServiceId { get; set; }
        public string InformationTechnologyServiceNm { get; set; }
        public string InformationDataClassificationNm { get; set; }
        public int SupplierId { get; set; }
        public string BusinessOrganizationNm { get; set; }
        public string TmModelNm { get; set; }
        public string PaceLayeringNm { get; set; }
        public string LogicalPlatformGroupNm { get; set; }
        public string ProductTypeNm { get; set; }
        public char InformationTechnologyManagedApplicationInd { get; set; }
        public string ApplicationOwningDepartmentCd { get; set; }
        public string ApplicationOwningDepartmentNm { get; set; }
        public string ApplicationOwningDepartmentHierarchyTxt { get; set; }
        public char ApplicationDevelopedByIntelInd { get; set; }
        public DateOnly? ApplicationEndOfLifeDt { get; set; }
        public DateOnly? TmModelEndDt { get; set; }
        public char? SaasSolutionInd { get; set; }
        public char? ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd { get; set; }
        public string ApplicationHostingTypeNm { get; set; }
        public string ApplicationValidationIssueTxt { get; set; }
        public DateTime? ApplicationValidationDtm { get; set; }
        public string ApplicationValidatedByWwid { get; set; }
        public string ApplicationOwningDepartmentLevel3Nm { get; set; }
        public string ApplicationOwningDepartmentLevel4Nm { get; set; }
        public string ApplicationOwningDepartmentLevel5Nm { get; set; }
        public char? SocialApplicationInd { get; set; }
        public string CreateAgentId { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ChangeAgentId { get; set; }
        public DateTime ChangeDtm { get; set; }
    }
}
