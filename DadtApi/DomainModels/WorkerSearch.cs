// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DadtApi.DomainModels
{
    public class WorkerSearch
    {
        public string Wwid { get; set; }
        public string DepartmentCd { get; set; }
        public string Idsid { get; set; }
        public string CcmailNm { get; set; }
        public string imageURL { get; set; }
        public string DepartmentLevel5Cd { get; set; }
        public string Status { get; set; }
        public string FullNm { get; set; }
    }
    public class AppContact
    {
        public string Wwid { get; set; }
        public string DepartmentCd { get; set; }
        public string Idsid { get; set; }
        public string CcmailNm { get; set; }
        public string imageURL { get; set; }
        public int ApplicationWorkerRoleId { get; set; }
        public string Status { get; set; }
        public string FullNm { get; set; }
    }

    public class WorkflowContact
    {
        public string Wwid { get; set; }
        public string Idsid { get; set; }
        public string FullNm { get; set; }
        public string CcmailNm { get; set; }
    }
}
