using DadtApi.DomainModels;
using DadtApi.Models;
using IAPServices.CommonUtility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DadtApi.CommonUtility
{
    public static class MetadataHandlers
    {
        public static ElmtMetadataBool MetaDataBuilderBool(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, bool value, int? iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();
            try
            {
                return new ElmtMetadataBool()
                {
                    Component = filteredList[0].WebObjectType,
                    Name = filteredList[0].WebObjectNm,
                    Label = filteredList[0].LabelTxt,
                    State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? false : (filteredList[0].InitialValueTxt == "0" ? false : true)) : value),
                    Placeholder = filteredList[0].PlaceholderTxt,
                    ValidationMsg = string.Empty,

                    MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                    MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                    ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                    ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                    DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                    MaxLength = filteredList[0].MaximumLengthNbr,
                    MinLength = filteredList[0].MinimumLengthNbr,

                    IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                    IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                    IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                    IsDisable = filteredList[0].DisableInd==CommonUtility.Constants.CHR_YES ? true: false,// Convert.ToBoolean(filteredList[0].DisableInd),
                    IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                    IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                    IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                    ClassName = Convert.ToString(filteredList[0].ClassNm),

                    DataSource = new List<keyvalue>(),
                    ChildElements = new List<ChildElement>(),
                    StateArrayObject = new List<int>(),
                    CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardSectionId = filteredList[0].WizardSectionId,
                    LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                    LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
                };
            }
            catch (Exception)
            {
                return new ElmtMetadataBool();
            }
        }
        public static ElmtMetadataString MetaDataBuilderString(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, string value, int iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataString()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? string.Empty : filteredList[0].InitialValueTxt) : value),
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                ClassName = Convert.ToString(filteredList[0].ClassNm),
                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }
        public static ElmtMetadataInt MetaDataBuilderInt(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, int value)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataInt()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = value,
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }
        public static ElmtMetadataArray MetaDataBuilderArray(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, List<int> value)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataArray()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = value,
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }
        public static ElmtMetadataKeyValueSearchArray MetaDataBuilderKeyValueArray(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, List<keyvalue> value)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataKeyValueSearchArray()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = value,
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }   
        public static ElmtMetadataWorkerSearchArray MetaDataBuilderArrayWorkerSearch(WebObjectMetadatum metaData, string attributeName, string attributeType, List<WorkerSearch> value)
        {
            return new ElmtMetadataWorkerSearchArray()
            {
                Component = metaData.WebObjectType,
                Id = Convert.ToInt32(metaData.WebObjectId),
                Name = metaData.WebObjectNm,
                Label = metaData.LabelTxt,
                State = value,
                Placeholder = metaData.PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(metaData.MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(metaData.MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(metaData.ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(metaData.ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(metaData.DataLoadApiUrl),

                MaxLength = metaData.MaximumLengthNbr,
                MinLength = metaData.MinimumLengthNbr,

                IsMinLengthMandatory = metaData.MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = metaData.MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = metaData.ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = metaData.DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = metaData.VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = metaData.OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = metaData.ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<WorkerSearch>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = metaData.CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = metaData.WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = metaData.WizardSectionId,
                LabelExtensionTxt = metaData.LabelExtensionTxt,
                LabelExtensionTxtClassNm = metaData.LabelExtensionTxtClassNm
            };
        }
         public static ElmtMetadataArrayActiveDirectoryGroup MetaDataBuilderArrayActivedirectorySearch(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, List<ActiveDirectoryGroupSearch> value)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataArrayActiveDirectoryGroup()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = value,
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),
                
                DataSource = new List<ActiveDirectoryGroupSearch>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }
          public static ElmtMetadataDecimal MetaDataBuilderDecimal(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, decimal value)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataDecimal()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = value,
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }
          public static ElmtMetadataIntNullable MetaDataBuilderInt(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, int? value)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataIntNullable()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = value,
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }

        //based on Id, Retireive metadata

        public static ElmtMetadataBool MetaDataBuilderBool(List<WebObjectMetadatum> listMetaData, int attributeId, string attributeType, string groupNm, bool value, int? iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectId == attributeId && o.WebObjectType.ToLower() == attributeType.ToLower() && o.GroupNm.ToLower() == groupNm.ToLower()).ToList();
            try
            {
                return new ElmtMetadataBool()
                {
                    Component = filteredList[0].WebObjectType,
                    Name = filteredList[0].WebObjectNm,
                    Label = filteredList[0].LabelTxt,
                    State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? false : (filteredList[0].InitialValueTxt == "0" ? false : true)) : value),
                    Placeholder = filteredList[0].PlaceholderTxt,
                    ValidationMsg = string.Empty,

                    MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                    MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                    ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                    ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                    DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                    MaxLength = filteredList[0].MaximumLengthNbr,
                    MinLength = filteredList[0].MinimumLengthNbr,

                    IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                    IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                    IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                    IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                    IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                    IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                    IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                    ClassName = Convert.ToString(filteredList[0].ClassNm),

                    DataSource = new List<keyvalue>(),
                    ChildElements = new List<ChildElement>(),
                    StateArrayObject = new List<int>(),
                    CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardSectionId = filteredList[0].WizardSectionId,
                    LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                    LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
                };
            }
            catch (Exception)
            {
                return new ElmtMetadataBool();
            }
        }

        public static ElmtMetadataString MetaDataBuilderString(List<WebObjectMetadatum> listMetaData, int attributeId, string attributeType, string groupNm, string value, int iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectId == attributeId && o.WebObjectType.ToLower() == attributeType.ToLower() && o.GroupNm.ToLower() == groupNm.ToLower()).ToList();

            return new ElmtMetadataString()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? string.Empty : filteredList[0].InitialValueTxt) : value),
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }

        public static ElmtMetadataBool MetaDataBuilderBool(List<WebObjectMetadatum> listMetaData, int attributeId, string groupNm, bool value, int? iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectId == attributeId && o.GroupNm.ToLower() == groupNm.ToLower()).ToList();
            try
            {
                return new ElmtMetadataBool()
                {
                    Component = filteredList[0].WebObjectType,
                    Name = filteredList[0].WebObjectNm,
                    Label = filteredList[0].LabelTxt,
                    State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? false : (filteredList[0].InitialValueTxt == "0" ? false : true)) : value),
                    Placeholder = filteredList[0].PlaceholderTxt,
                    ValidationMsg = string.Empty,

                    MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                    MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                    ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                    ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                    DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                    MaxLength = filteredList[0].MaximumLengthNbr,
                    MinLength = filteredList[0].MinimumLengthNbr,

                    IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                    IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                    IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                    IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                    IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                    IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                    IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                    ClassName = Convert.ToString(filteredList[0].ClassNm),

                    DataSource = new List<keyvalue>(),
                    ChildElements = new List<ChildElement>(),
                    StateArrayObject = new List<int>(),
                    CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardSectionId = filteredList[0].WizardSectionId,
                    LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                    LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
                };
            }
            catch (Exception)
            {
                return new ElmtMetadataBool();
            }
        }

        public static ElmtMetadataString MetaDataBuilderString(List<WebObjectMetadatum> listMetaData, int attributeId, string groupNm, string value, int iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectId == attributeId && o.GroupNm.ToLower() == groupNm.ToLower()).ToList();

            return new ElmtMetadataString()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? string.Empty : filteredList[0].InitialValueTxt) : value),
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),


                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }

        public static ElmtMetadataString MetaDataBuilderString(WebObjectMetadatum metaData, string value, int iapId)
        {
            return new ElmtMetadataString()
            {
                Component = metaData.WebObjectType,
                Name = metaData.WebObjectNm,
                Label = metaData.LabelTxt,
                State = (iapId == 0 ? (string.IsNullOrEmpty(metaData.InitialValueTxt) ? string.Empty : metaData.InitialValueTxt) : value),
                Placeholder = metaData.PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(metaData.MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(metaData.MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(metaData.ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(metaData.ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(metaData.DataLoadApiUrl),

                MaxLength = metaData.MaximumLengthNbr,
                MinLength = metaData.MinimumLengthNbr,

                IsMinLengthMandatory = metaData.MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = metaData.MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = metaData.ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = metaData.DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = metaData.VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = metaData.OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = metaData.ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                DataSource = new List<keyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = metaData.CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = metaData.WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = metaData.WizardSectionId,
                LabelExtensionTxt = metaData.LabelExtensionTxt,
                LabelExtensionTxtClassNm = metaData.LabelExtensionTxtClassNm
            };
        }

        public static ElmtMetadataBool MetaDataBuilderBool(WebObjectMetadatum metaData, bool value, int? iapId)
        {
            try
            {
                return new ElmtMetadataBool()
                {
                    Component = metaData.WebObjectType,
                    Name = metaData.WebObjectNm,
                    Label = metaData.LabelTxt,
                    State = (iapId == 0 ? (string.IsNullOrEmpty(metaData.InitialValueTxt) ? false : (metaData.InitialValueTxt == "0" ? false : true)) : value),
                    Placeholder = metaData.PlaceholderTxt,
                    ValidationMsg = string.Empty,

                    MandatoryValidationMsg = Convert.ToString(metaData.MandatoryValidationMessageTxt),
                    MinLengthValidationMessage = Convert.ToString(metaData.MinimumLengthValidationMessageTxt),
                    ToolTip = Convert.ToString(metaData.ToolTipMessageTxt),
                    ValuePresentIndicatorValidationMsg = Convert.ToString(metaData.ValuePresentIndValidationMessageTxt),
                    DataSourceApiUrl = Convert.ToString(metaData.DataLoadApiUrl),

                    MaxLength = metaData.MaximumLengthNbr,
                    MinLength = metaData.MinimumLengthNbr,

                    IsMinLengthMandatory = metaData.MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                    IsMandatory = metaData.MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                    IsToolTipMandatory = metaData.ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                    IsDisable = metaData.DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                    IsVisible = metaData.VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                    IsOnDemandDataLoad = metaData.OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                    IsValueSingleSelect = metaData.ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),

                    ClassName = Convert.ToString(metaData.ClassNm),

                    DataSource = new List<keyvalue>(),
                    ChildElements = new List<ChildElement>(),
                    StateArrayObject = new List<int>(),
                    CertifyInd = metaData.CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardInd = metaData.WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                    WizardSectionId = metaData.WizardSectionId,
                    LabelExtensionTxt = metaData.LabelExtensionTxt,
                    LabelExtensionTxtClassNm = metaData.LabelExtensionTxtClassNm
                };
            }
            catch (Exception)
            {
                return new ElmtMetadataBool();
            }
        }

        public static ElmtMetadataString2 MetaDataBuilderString2(List<WebObjectMetadatum> listMetaData, string attributeName, string attributeType, string value, int iapId)
        {
            List<WebObjectMetadatum> filteredList = listMetaData.Where(o => o.WebObjectNm.ToLower() == attributeName.ToLower() && o.WebObjectType == attributeType).ToList();

            return new ElmtMetadataString2()
            {
                Component = filteredList[0].WebObjectType,
                Name = filteredList[0].WebObjectNm,
                Label = filteredList[0].LabelTxt,
                State = (iapId == 0 ? (string.IsNullOrEmpty(filteredList[0].InitialValueTxt) ? string.Empty : filteredList[0].InitialValueTxt) : value),
                Placeholder = filteredList[0].PlaceholderTxt,
                ValidationMsg = string.Empty,

                MandatoryValidationMsg = Convert.ToString(filteredList[0].MandatoryValidationMessageTxt),
                MinLengthValidationMessage = Convert.ToString(filteredList[0].MinimumLengthValidationMessageTxt),
                ToolTip = Convert.ToString(filteredList[0].ToolTipMessageTxt),
                ValuePresentIndicatorValidationMsg = Convert.ToString(filteredList[0].ValuePresentIndValidationMessageTxt),
                DataSourceApiUrl = Convert.ToString(filteredList[0].DataLoadApiUrl),

                MaxLength = filteredList[0].MaximumLengthNbr,
                MinLength = filteredList[0].MinimumLengthNbr,

                IsMinLengthMandatory = filteredList[0].MinimumLengthMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MinimumLengthMandatoryInd) == 1 ? true : false,
                IsMandatory = filteredList[0].MandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].MandatoryInd) == 1 ? true : false,
                IsToolTipMandatory = filteredList[0].ToolTipMandatoryInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToSByte(filteredList[0].ToolTipMandatoryInd) == 1 ? true : false,

                IsDisable = filteredList[0].DisableInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].DisableInd),
                IsVisible = filteredList[0].VisibilityInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].VisibilityInd),
                IsOnDemandDataLoad = filteredList[0].OnDemandDataLoadInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].OnDemandDataLoadInd),
                IsValueSingleSelect = filteredList[0].ValueSingleSelectInd == CommonUtility.Constants.CHR_YES ? true : false,// Convert.ToBoolean(filteredList[0].ValueSingleSelectInd),


                DataSource = new List<stringkeyvalue>(),
                ChildElements = new List<ChildElement>(),
                StateArrayObject = new List<int>(),
                CertifyInd = filteredList[0].CertifyInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardInd = filteredList[0].WizardInd == CommonUtility.Constants.CHR_YES ? true : false,
                WizardSectionId = filteredList[0].WizardSectionId,
                LabelExtensionTxt = filteredList[0].LabelExtensionTxt,
                LabelExtensionTxtClassNm = filteredList[0].LabelExtensionTxtClassNm
            };
        }
    }
}
