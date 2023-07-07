using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class WebObjectMetadatum
    {
        public int WebObjectMetadataId { get; set; }
        public int? WebObjectId { get; set; }
        public string WebObjectNm { get; set; }
        public string WebObjectType { get; set; }
        public string ClassNm { get; set; }
        public string DataLoadApiUrl { get; set; }
        public char DisableInd { get; set; }
        public string GroupNm { get; set; }
        public int? DisplayOrderNbr { get; set; }
        public string InitialValueTxt { get; set; }
        public string LabelTxt { get; set; }
        public char MandatoryInd { get; set; }
        public string MandatoryValidationMessageTxt { get; set; }
        public int MaximumLengthNbr { get; set; }
        public char MinimumLengthMandatoryInd { get; set; }
        public int MinimumLengthNbr { get; set; }
        public string MinimumLengthValidationMessageTxt { get; set; }
        public char OnDemandDataLoadInd { get; set; }
        public string PageNm { get; set; }
        public string PlaceholderTxt { get; set; }
        public int TabId { get; set; }
        public char ToolTipMandatoryInd { get; set; }
        public string ToolTipMessageTxt { get; set; }
        public string ValuePresentIndValidationMessageTxt { get; set; }
        public char ValueSingleSelectInd { get; set; }
        public char VisibilityInd { get; set; }
        public char CertifyInd { get; set; }
        public char WizardInd { get; set; }
        public int? WizardSectionId { get; set; }
        public string LabelExtensionTxt { get; set; }
        public string LabelExtensionTxtClassNm { get; set; }
        public string CreateAgentId { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ChangeAgentId { get; set; }
        public DateTime ChangeDtm { get; set; }
    }
}
