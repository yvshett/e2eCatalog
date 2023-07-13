using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using DadtApi.Context;
using System.IO;
using System.Net;
using DadtApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DadtApi.CommonUtility
{
    public interface IEmailService
    {
      
        Task SendEmailMessageAsync(string to, string cc, string subject, string body, string mailCategory, string headerTitle = "", int mailId = 0);
        Task SendEmailDataGovernanceReportAsync(string to, string subject, string body, List<string> csvData);
        string GetSystemconfiguration(string key);
    }

   
}
