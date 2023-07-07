using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class Worker
    {
        public string Wwid { get; set; }
        public string DepartmentCd { get; set; }
        public string FullNm { get; set; }
        public string NickNm { get; set; }
        public string FirstNm { get; set; }
        public string Idsid { get; set; }
        public string CorporateEmailTxt { get; set; }
        public string CcmailNm { get; set; }
        public char PersonStatusTypeCd { get; set; }
        public string DepartmentNm { get; set; }
        public string ManagerWwid { get; set; }
        public string ManagerFullNm { get; set; }
        public string CostCenterCd { get; set; }
        public string SuperGroupLongNm { get; set; }
        public string SuperGroupCd { get; set; }
        public string GroupLongNm { get; set; }
        public string DivisionLongNm { get; set; }
        public string WorkLocationBuildingNm { get; set; }
        public string WorkLocationSiteNm { get; set; }
        public string WorkLocationCountryNm { get; set; }
        public string CreateAgentId { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ChangeAgentId { get; set; }
        public DateTime ChangeDtm { get; set; }

        public virtual Department DepartmentCdNavigation { get; set; }
    }
}
