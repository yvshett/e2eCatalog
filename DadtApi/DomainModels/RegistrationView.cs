using System.Collections.Generic;

namespace DadtApi.DomainModels
{
    public class RegistrationView
    {
        public ApplicationDetailsView appDetailsView { get; set; }

        public ApplicationUsageView usageView { get; set; }

        public RolesandContactsView rolesandcontactsview { get; set; }

        public BusinessInformationView businessinformationview { get; set; }

        public TechnicalComponentsView technicalcomponentsView { get; set; }

        public FinancialsView financialsview { get; set; }

        public RelatedMetricsView relatedmetrics { get; set; }

        public SupportingDocuments supportingDocuments { get; set; }

        public Statusview statusview { get; set; }




    }

    public class ApplicationDetailsView
    {
        public ElementMetadata AppName { get; set; }

        public ElementMetadata AppId { get; set; }

        public ElementMetadata Acronym { get; set; }

        public ElementMetadata LifeCycleStatus { get; set; }

        public ElementMetadata ProductOwner { get; set; }

        public ElementMetadata AppDescription { get; set; }
    }

    public class ElementMetadata
    {
        public string Component { get; set; } //'Component' ----------> 'AUTOSUGGEST'

        public string Name { get; set; } //'Name' ----------> 'ApplicationNm'

        public string Label { get; set; } //'Label' ----------> 'Application Name'

        public string className { get; set; } //'className' ----------> 'form-control'

        public string State { get; set; } //'State' ----------> 'Finance DSS'

        public string Placeholder { get; set; } //'Placeholder' ----------> 'Enter your app name'

        public string ValidationMsg { get; set; } //'ValidationMsg' ----------> ''

        public bool IsMandatory { get; set; } //'IsMandatory' ----------> true indicates validation is mandatory

        public string MandatoryValidationMsg { get; set; } //'MandatoryValidationMsg' ----------> 'Application Acronym Name is must to have'

        public int MaxLength { get; set; } //'MaxLength' ----------> 50

        public int MinLength { get; set; } //'MinLength' ----------> 2

        public bool IsMinLengthMandatory { get; set; } //'IsMinLengthMandatory' ----------> true

        public string MinLengthValidationMessage { get; set; } //'MinLengthValidationMessage' ----------> 'Application Acronym Name is must be <=2 characters'

        public bool IsToolTipMandatory { get; set; } //'IsToolTipMandatory' ----------> 'true'

        public string ToolTip { get; set; } //'ToolTip' ----------> 'Short name for your application'

        public List<keyvalue> DataSource { get; set; } //'DataSource' ----------> 'key value list for data for all sources'

    }

    public class ApplicationUsageView
    {
        public ElementMetadata DevelopedBy { get; set; }
        public ElementMetadata IntelDeveloped { get; set; }

        public ElementMetadata ITService { get; set; }

        public ElementMetadata InformationClassification { get; set; }

        public ElementMetadata TierSupport { get; set; }

        public ElementMetadata TIMEProperty { get; set; }

        public ElementMetadata TIMEPropertyValidityDate { get; set; }

        public ElementMetadata TIMEJustification { get; set; }

        public ElementMetadata PACELayering { get; set; }

        public ElementMetadata CustomerBase { get; set; }

        public string Caption { get; set; }

        public ElementMetadata UsageDefination { get; set; }

        public ElementMetadata UsageAdoptionGoalDate { get; set; }

        public ElementMetadata UsageDetails { get; set; }

        public ElementMetadata OwningOrg { get; set; }

        public List<URLInfoList> URLList { get; set; }

        public string UrlCaption { get; set; }

        public List<ApplicationUsageMetricView> listUsageMetric { get; set; }
    }

    public class URLInfoList
    {
        
        public string URLUsage { get; set; }

        public string URLName { get; set; }

        public string URL { get; set; }
    }

    public class ApplicationUsageMetricView
    {
        public int Order { get; set; }

        public ElementMetadata UsageType { get; set; }

        public string TargetCount { get; set; }

        public string ActualCount { get; set; }
    }


    // Roles and contacts

    public class RolesandContactsView
    {

        public List<RoleList> roleLists { get; set; }

        public List<RolesandContacts> listRolesandContacts { get; set; }
    }

    public class RolesandContacts
    {
        public string Caption { get; set; }
        public List<Roles> listRoles { get; set; }
    }

    public class Roles
    {
        public string Name { get; set; }
        public string WwId { get; set; }

        public string Image { get; set; }

        public string Message { get; set; }

        public string Role { get; set; }

    }

    public class RoleList
    {
        public string Role { get; set; }

        public string Name { get; set; }

        public string WwId { get; set; }

    }

    // business information

    public class BusinessInformationView
    {
        public ElementMetadata Caption { get; set; }

        public ElementMetadata BusinessCapability { get; set; }

        public ElementMetadata BusinessCapabilityValue { get; set; }

        public ElementMetadata ApptoPlatformMapping { get; set; }

        public ElementMetadata BusinessProcessMapping { get; set; }
    }

    // Technical Components

    public class TechnicalComponentsView
    {
        public ElementMetadata Caption { get; set; }

        public List<HostingEnvironmentList> hostingenvironmentlist { get; set; }

        public UserInferface userinferface { get; set; }

        public MiddlewareWorkflow middlewareworkflow { get; set; }

        public DataStore datastore { get; set; }

        public BI bi { get; set; }

        public OS os { get; set; }

        public Miscellaneous miscellaneous { get; set; }

    }

    public class Miscellaneous
    {
        public string title { get; set; }

        public string subtitle { get; set; }

        public string Label { get; set; }

        public List<ElementMetadata> Data { get; set; }
    }
    public class OS
    {
        public string title { get; set; }

        public string subtitle { get; set; }

        public string Label { get; set; }

        public List<ElementMetadata> Data { get; set; }
    }

    public class BI
    {
        public string title { get; set; }

        public string subtitle { get; set; }

        public string Label { get; set; }

        public List<ElementMetadata> Data { get; set; }
    }

    public class DataStore
    {
        public string title { get; set; }

        public string subtitle { get; set; }

        public string Label { get; set; }

        public List<ElementMetadata> Data { get; set; }
    }

    public class MiddlewareWorkflow
    {
        public string title { get; set; }

        public string subtitle { get; set; }

        public string Label { get; set; }

        public List<ElementMetadata> Data { get; set; }
    }

    public class UserInferface
    {
        public string title { get; set; }

        public string subtitle { get; set; }

        public string Label { get; set; }

        public List<ElementMetadata> Data { get; set; }

    }

    public class HostingEnvironmentList
    {
        public string title { get; set; }

        public string Label { get; set; }

        public string Environment { get; set; }

        public string Network { get; set; }

        public string Location { get; set; }
    }

    // Financials

    public class FinancialsView
    {
        public string Caption { get; set; }


        public FinancialsDetails financialsdetails { get; set; }

        public List<FinancialsList> financialslist { get; set; }

        public ElementMetadata detailsjustification { get; set; }


        public CostHistoricalTrend trend { get; set; }

    }

    public class CostHistoricalTrend
    {
        public ElementMetadata caption { get; set; }

        public List<ElementMetadata> trenddata { get; set; }
    }

    public class FinancialsDetails
    {

        public string Year { get; set; }

        public string Note { get; set; }

        public string LastUpdatedOn { get; set; }

        public string ToolTip { get; set; }

        public string UpdatedByLabel { get; set; }

        public string UpdatedName { get; set; }
    }

    public class FinancialsList
    {
        public string Label { get; set; }

        public string AnnualCost { get; set; }

        public string Quarter1 { get; set; }

        public string Quarter2 { get; set; }

        public string Quarter3 { get; set; }

        public string Quarter4 { get; set; }

        public ElementMetadata CostComponents { get; set; }

        public ElementMetadata businessvalue { get; set; }
    }

    // Related Metrics


    public class RelatedMetricsView
    {
        public AssetDependancies assetdependancies { get; set; }

        public OperationalMetrics operationalmetrics { get; set; }

        public List<OutofComplaince> outofcomplaince { get; set; }
    }

    public class OutofComplaince
    {
        public string title { get; set; }

        public string label { get; set; }

        public string sublabel { get; set; }

        public List<ElementMetadata> data { get; set; }

    }

    public class OperationalMetrics
    {
        public string Label { get; set; }

        public List<ElementMetadata> operationalmetricstrend { get; set; }


    }

    public class AssetDependancies
    {
        public string Label { get; set; }

        public List<ElementMetadata> assets { get; set; }
    }


    // supporting Documents

    public class SupportingDocuments
    {
        public string Label { get; set; }

        public List<DocumentsList> documents { get; set; }
    }


    public class DocumentsList
    {
        public string title { get; set; }

        public string documents { get; set; }

        public string label { get; set; }


    }

    // Status


    public class Statusview
    {
        public WorkFlowApproval workflow { get; set; }

        public BeforeApproval beforeApproval { get; set; }

        public AdditionalSteps additionalsteps { get; set; }

    }

    public class AdditionalSteps
    {
        public string Caption { get; set; }
        public List<ElementMetadata> additionalsteps { get; set; }
    }

    public class BeforeApproval
    {
        public string label { get; set; }
    }

    public class WorkFlowApproval
    {
        public string label { get; set; }

        public string SenderName { get; set; }

        public string ReceiverName { get; set; }

        public string SenderRole { get; set; }

        public string ReceiverRole { get; set; }

        public string SenderStatus { get; set; }

        public string ReceiverStatus { get; set; }

        public string SubmissionLabel { get; set; }

        public string senderSubmissionDate { get; set; }

        public string ReceiverSubmissionDate { get; set; }

        public string RemaiderLabel { get; set; }

        public string RemainderDate { get; set; }

        public string SenderImage { get; set; }

        public string ReceiverImage { get; set; }

        public string SendRemainderLabel { get; set; }

        public string view { get; set; }


    }


    public class keyvalue
    {
        public int order { get; set; }
        public int key { get; set; }
        public string value { get; set; }
        public string desc { get; set; }
        public string tooltip { get; set; }
        public string status { get; set; }
        public string validationMsg { get; set; }
    }

    public class stringkeyvalue
    {
        public string key { get; set; }
        public string value { get; set; }
        public string desc { get; set; }
        public string tooltip { get; set; }
    }
}
