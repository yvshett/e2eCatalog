using DadtApi.Models;
using IAPServices.CommonUtility;
using System;
using System.Collections.Generic;

namespace DadtApi.DomainModels
{

    public class ElmtMetadataBase
    {
        public List<int> StateArrayObject { get; set; } //'State' ----------> 'Finance DSS' 

        public string Section { get; set; } //'Component' ----------> 'AUTOSUGGEST'

        public string Component { get; set; } //'Component' ----------> 'AUTOSUGGEST'

        public string Name { get; set; } //'Name' ----------> 'ApplicationNm'

        public int Id { get; set; } //'Id' ----------> '1 for Product Owner'

        public string Label { get; set; } //'Label' ----------> 'Application Name'

        public string Placeholder { get; set; } //'Placeholder' ----------> 'Enter your app name'

        public string ValidationMsg { get; set; } //'ValidationMsg' ----------> ''

        public string ClassName { get; set; } //'className' ----------> 'form-control'

        public bool IsMandatory { get; set; } //'IsMandatory' ----------> true indicates validation is mandatory

        public string MandatoryValidationMsg { get; set; } //'MandatoryValidationMsg' ----------> 'Application Acronym Name is must to have'

        public int MaxLength { get; set; } //'MaxLength' ----------> 50

        public int MinLength { get; set; } //'MinLength' ----------> 2

        public bool IsMinLengthMandatory { get; set; } //'IsMinLengthMandatory' ----------> true

        public string MinLengthValidationMessage { get; set; } //'MinLengthValidationMessage' ----------> 'Application Acronym Name is must be <=2 characters'

        public bool IsToolTipMandatory { get; set; } //'IsToolTipMandatory' ----------> 'true'

        public string ToolTip { get; set; } //'ToolTip' ----------> 'Short name for your application'

        public bool IsDisable { get; set; }  //'IsDisable' ----------> 'true'

        public bool IsVisible { get; set; }  //'IsVisible' ----------> 'true'

        public bool IsOnDemandDataLoad { get; set; }  //'IsOnDemandDataLoad' ----------> 'true', for on demnd api load data for DataSource filed

        public string DataSourceApiUrl { get; set; } //'"apiUrl": "/api/ApplicationMasterData/InformationTechnologySupportTier",

        public string ValuePresentIndicatorValidationMsg { get; set; } //'ValuePresentIndicatorValidationMsg' ---------->"Name already exists.  Please select a different name"

        public bool IsHavingChildrens { get; set; }

        public bool IsValueSingleSelect { get; set; }

        //public string ClassNm { get; set; }

        public List<ChildElement> ChildElements { get; set; }

        public bool CertifyInd { get; set; }

        public bool WizardInd { get; set; }

        public int? WizardSectionId { get; set; }

        public string LabelExtensionTxt { get; set; }

        public string LabelExtensionTxtClassNm { get; set; }

    }

    public class ElmtMetadataDataSourceKeyValue : ElmtMetadataBase
    {
        public List<keyvalue> DataSource { get; set; } //'DataSource' ----------> 'key value list for data for all sources'
    }

    public class ElmtMetadataDataSourceStringKeyValue : ElmtMetadataBase
    {
        public List<stringkeyvalue> DataSource { get; set; } //'DataSource' ----------> 'key value list for data for all sources'
    }

    public class ElmtMetadataDataSourceUser : ElmtMetadataBase
    {
        public List<WorkerSearch> DataSource { get; set; } //'DataSource' ----------> 'key value list for data for all sources'
    }

    public class ElmtMetadataDataSourceActiveDirectoryGroup : ElmtMetadataBase
    {
        public List<ActiveDirectoryGroupSearch> DataSource { get; set; } //'DataSource' ----------> 'key value list for data for all sources'
    }


    public class ElmtMetadataString : ElmtMetadataDataSourceKeyValue
    {
        public string State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataString2 : ElmtMetadataDataSourceStringKeyValue
    {
        public string State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataInt : ElmtMetadataDataSourceKeyValue
    {
        public int State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataIntNullable : ElmtMetadataDataSourceKeyValue
    {
        public int? State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataDecimal : ElmtMetadataDataSourceKeyValue
    {
        public decimal State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataBool : ElmtMetadataDataSourceKeyValue
    {
        public bool State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataArray : ElmtMetadataDataSourceKeyValue
    {
        public List<int> State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataArrayActiveDirectoryGroup : ElmtMetadataDataSourceActiveDirectoryGroup
    {
        public List<ActiveDirectoryGroupSearch> State { get; set; } //'State'
    }


    public class ElmtMetadataUserArray : ElmtMetadataDataSourceUser
    {
        public List<int> State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataWorkerSearchArray : ElmtMetadataDataSourceUser
    {
        public List<WorkerSearch> State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataKeyValueSearchArray : ElmtMetadataDataSourceKeyValue
    {
        public List<keyvalue> State { get; set; } //'DataSource' ----------> 'key value list for data for all sources'
    }

    public class ElmtMetadataStringArray : ElmtMetadataDataDocumentsArray
    {
        public string State { get; set; } //'State' ----------> 'Finance DSS'
    }

    public class ElmtMetadataDataDocumentsArray : ElmtMetadataBase
    {
        public List<keyvalue> DataSource { get; set; } //'DataSource' ----------> 'key value list for data for all sources'
    }

    public class UserProp : keyvalue
    {
        public string imageBaseUrl { get; set; }

        public string location { get; set; }
    }

    public class Organizations
    {
        public bool IsItOrg { get; set; }

        public ElmtMetadataString header { get; set; }

        public ElmtMetadataString sectionOwnedByOrganization { get; set; }

        public ElmtMetadataString sectionHrHierarchy { get; set; }

        public ElmtMetadataString sectionFinanceHierarchy { get; set; }

        public ElmtMetadataString sectionOwnedByItService { get; set; }

        public ElmtMetadataString itService { get; set; }

        public ElmtMetadataString sectionSupportedByItService { get; set; }

        public ElmtMetadataString supportedItService { get; set; }

        public ElmtMetadataBool isSupportedBySupplier { get; set; }

        public ElmtMetadataString sectionOwnedByIntelOrg { get; set; }

        public ElmtMetadataString sectionActiveDirectoryGroup { get; set; }

        public ElmtMetadataArrayActiveDirectoryGroup ActiveDirectoryGroup { get; set; }

    }

    public class ChildElement
    {
        public string Name { get; set; }

        public string Action { get; set; }

        public bool Value { get; set; }

        public bool DefaultValue { get; set; }
    }

    public class TabDetails
    {
        public ElmtMetadataString Key { get; set; }

        public ElmtMetadataString Label { get; set; }

        public ElmtMetadataString IsSelected { get; set; }

        public ElmtMetadataString IsValid { get; set; }

        public ElmtMetadataString ValidationMessage { get; set; }
    }

  
    public class TechnologyTypeWithId
    {
        public int TechnologyTypeId { get; set; }
        public int TechnologyId { get; set; }
    }
    public class LifecycleStatusHistoryDetails
    {
        public DateTime ValueChangeDtm { get; set; }
        public string NewValueTxt { get; set; }
    }
    public class PublishToStoreDetails
    {              
        public List<ElmtMetadataString> listPublishToStoreDetails { get; set; }
    }

}
