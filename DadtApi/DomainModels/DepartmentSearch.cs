// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DadtApi.DomainModels
{
    public class DepartmentSearch
    {
        public string DepartmentCd { get; set; }
        public string DepartmentNm { get; set; }
        public string DepartmentHierarchy { get; set; }
        public char ActiveInd { get; set; }
    }

    public partial class OrgContact
    {
        public int RoleId { get; set; }
        public string Wwid { get; set; }
    }
}
