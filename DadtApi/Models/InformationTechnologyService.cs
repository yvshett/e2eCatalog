using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class InformationTechnologyService
    {
        public int InformationTechnologySegmentId { get; set; }
        public int InformationTechnologyServiceId { get; set; }
        public string ServiceOwnerWwid { get; set; }
        public string ServiceDelegateWwid { get; set; }
        public string InformationTechnologyServiceNm { get; set; }
        public string InformationTechnologyServicePhaseCd { get; set; }
        public DateTime InformationTechnologyServiceEndDt { get; set; }
        public DateTime InformationTechnologyServiceStartDt { get; set; }
        public char? InformationTechnologyServiceInd { get; set; }
        public string CreateAgentId { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ChangeAgentId { get; set; }
        public DateTime ChangeDtm { get; set; }
    }
}
