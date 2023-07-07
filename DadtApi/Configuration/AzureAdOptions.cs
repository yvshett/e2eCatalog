﻿namespace DadtApi.Configuration
{
    public class AzureAdOptions
    {
        public string Instance { get; set; }
        public string ClientId { get; set; }
        public string Tenant { get; set; }
        public string Authority => Instance + Tenant;

        public string ClientEncyptedSecret { get; set; }
    }
}
