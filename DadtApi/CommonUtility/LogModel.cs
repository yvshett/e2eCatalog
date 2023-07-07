namespace DadtApi.CommonUtility
{
    public class LogModel
    {
        public string MachineAccount { get; set; }
        public string LogType { get; set; }
        public string LogCategory { get; set; }
        public string StepName { get; set; }
        public string StepDetail { get; set; }
        public string DBName { get; set; }
        public string SchemaName { get; set; }
        public string ServerMachineIP { get; set; }
        public string ServerMachineName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string SessionId { get; set; }
        public Custom Custom { get; set; }

    }
    public class Custom
    {
        public string str_org { get; set; }
        public string str_dadt_environment { get; set; }
    }
}
