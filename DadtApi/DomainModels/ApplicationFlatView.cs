using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DadtApi.DomainModels
{

    public class AllSolutionsView
    {
        public int ApplicationId { get; set; }
        public string ApplicationNm { get; set; }
        public string ApplicationAcronymNm { get; set; }
        public string ApplicationDetailsUrlTxt { get; set; }
        public string ApplicationClassificationNm { get; set; }
        public string ProductOwnerNm { get; set; }
        public string SuperGroupLongNm { get; set; }
        public string GroupLongNm { get; set; }
        public string DivisionLongNm { get; set; }
        public string ApplicationLifecycleStatusNm { get; set; }
        public int ApplicationLifecycleStatusMonthCount { get; set; }
        public DateTime? ApplicationLifecycleStatusEndDtm { get; set; }
        public string ApplicationUserBaseNm { get; set; }
        public string InformationTechnologySupportTierNm { get; set; }
        public string InformationTechnologyServiceNm { get; set; }
        public string InformationDataClassificationNm { get; set; }
        public string BusinessOrganizationNm { get; set; }
        public string TmModelNm { get; set; }
        public string PaceLayeringNm { get; set; }
        public Char InformationTechnologyManagedApplicationInd { get; set; }
        public string ApplicationOwningDepartmentNm { get; set; }
        public string PublishInd { get; set; }
        public DateOnly? TmModelEndDt { get; set; }
        public string SaasSolutionInd { get; set; }
        public string ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd { get; set; }
        public string ApplicationHostingTypeNm { get; set; }
        public string ApplicationOwningDepartmentLevel4Nm { get; set; }
        public string ApplicationOwningDepartmentLevel3Nm { get; set; }
        public string CapabilityNm { get; set; }
        public string BusinessOwnerNm { get; set; }
    }

    public class MySolutionsView
    {
        public int ApplicationId { get; set; }
        public string ApplicationNm { get; set; }
        public string ApplicationAcronymNm { get; set; }
        public string ApplicationClassificationNm { get; set; }
        public string ProductOwnerNm { get; set; }
        public string ApplicationLifecycleStatusNm { get; set; }
        public DateTime? ApplicationLifecycleStatusEndDtm { get; set; }
        public string ApplicationUserBaseNm { get; set; }
        public string InformationTechnologySupportTierNm { get; set; }
        public string InformationTechnologyServiceNm { get; set; }
        public string InformationDataClassificationNm { get; set; }
        public string BusinessOrganizationNm { get; set; }
        public string TmModelNm { get; set; }
        public string PaceLayeringNm { get; set; }
        public string InformationTechnologyManagedApplicationInd { get; set; }
        public string PublishInd { get; set; }
        public DateTime? TmModelEndDt { get; set; }
        public string SaasSolutionInd { get; set; }
        public string ApplicationHostingTypeNm { get; set; }
        public string CapabilityNm { get; set; }

    }

    public class MyPendingsView
    {
        public int ApplicationId { get; set; }
        public string ApplicationNm { get; set; }
        public string ApplicationAcronymNm { get; set; }
        public string ApplicationClassificationNm { get; set; }
        public string ProductOwnerNm { get; set; }
        public string ApplicationLifecycleStatusNm { get; set; }
        public string ApplicationValidationIssueTxt { get; set; }
        public int WorkflowId { get; set; }
        public string WorkflowType { get; set; }
        public string WorkflowReviewerList { get; set; }
        public string ApproverInd { get; set; }
        public string DisplayApplicationId { get; set; }
        public string ApplicationDraftStatusInd { get; set; }
        public string PegaCaseDetailsUrl { get; set; }
        public string ProductOwnerEmail { get; set; }
        public string IsITApp { get; set; }
        public string CertifyInd { get; set; }
    }

}
