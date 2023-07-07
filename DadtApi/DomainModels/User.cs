// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DadtApi.DomainModels
{
    public class User
    {
        public string Wwid { get; set; }
        public string DepartmentCd { get; set; }
        public string FullNm { get; set; }
        public string NickNm { get; set; }
        public string FirstNm { get; set; }
        public string Idsid { get; set; }
        public string CorporateEmailTxt { get; set; }
        public string CcmailNm { get; set; }
        public string DepartmentNm { get; set; }
        public string WorkLocationBuildingNm { get; set; }
        public string WorkLocationSiteNm { get; set; }
        public string WorkLocationCountryNm { get; set; }
        public string imageURL { get; set; }
        public int IsITOrg { get; set; }
        public string HumanResourceHierarchy { get; set; }
        public string FinanceHierarchy { get; set; }
        public string DepartmentLevel5Cd { get; set; }
    }

    public class UserMe:User
    {
        public string adminInd { get; set; }
    }

}
