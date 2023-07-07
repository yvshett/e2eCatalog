using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }

        public string DepartmentCd { get; set; }
        public string TreeLevelNbr { get; set; }
        public string DepartmentNm { get; set; }
        public string DepartmentLevel1Cd { get; set; }
        public string DepartmentLevel2Cd { get; set; }
        public string DepartmentLevel3Cd { get; set; }
        public string DepartmentLevel4Cd { get; set; }
        public string DepartmentLevel5Cd { get; set; }
        public string DepartmentLevel6Cd { get; set; }
        public string DepartmentLevel7Cd { get; set; }
        public string DepartmentLevel8Cd { get; set; }
        public string DepartmentLevel9Cd { get; set; }
        public string DepartmentLevel10Cd { get; set; }
        public string DepartmentLevel11Cd { get; set; }
        public string DepartmentLevel12Cd { get; set; }
        public string DepartmentLevel13Cd { get; set; }
        public string DepartmentLevel14Cd { get; set; }
        public string DepartmentLevel15Cd { get; set; }
        public string DepartmentLevel16Cd { get; set; }
        public string DepartmentLevel17Cd { get; set; }
        public string DepartmentLevel18Cd { get; set; }
        public string DepartmentLevel19Cd { get; set; }
        public string DepartmentLevel20Cd { get; set; }
        public string DepartmentLevel1Nm { get; set; }
        public string DepartmentLevel2Nm { get; set; }
        public string DepartmentLevel3Nm { get; set; }
        public string DepartmentLevel4Nm { get; set; }
        public string DepartmentLevel5Nm { get; set; }
        public string DepartmentLevel6Nm { get; set; }
        public string DepartmentLevel7Nm { get; set; }
        public string DepartmentLevel8Nm { get; set; }
        public string DepartmentLevel9Nm { get; set; }
        public string DepartmentLevel10Nm { get; set; }
        public string DepartmentLevel11Nm { get; set; }
        public string DepartmentLevel12Nm { get; set; }
        public string DepartmentLevel13Nm { get; set; }
        public string DepartmentLevel14Nm { get; set; }
        public string DepartmentLevel15Nm { get; set; }
        public string DepartmentLevel16Nm { get; set; }
        public string DepartmentLevel17Nm { get; set; }
        public string DepartmentLevel18Nm { get; set; }
        public string DepartmentLevel19Nm { get; set; }
        public string DepartmentLevel20Nm { get; set; }
        public char ActiveInd { get; set; }
        public string CreateAgentId { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ChangeAgentId { get; set; }
        public DateTime ChangeDtm { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
