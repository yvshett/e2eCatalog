using System;
using System.Collections.Generic;

namespace DadtApi.Models
{
    public partial class SystemConfiguration
    {
        public string ConfigurationKey { get; set; }
        public string ConfigurationValue { get; set; }
        public string ConfigurationDsc { get; set; }
        public string ActiveInd { get; set; }
        public string CreateAgentId { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ChangeAgentId { get; set; }
        public DateTime ChangeDtm { get; set; }
    }
}
