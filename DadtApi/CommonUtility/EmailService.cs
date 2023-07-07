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

    public class EmailService : IEmailService
    {
        public IConfiguration _configuration { get; }

        private readonly dbContext _context;

        public string from; string server; int port;
        public EmailService(IConfiguration configuration, dbContext context)
        {
            _context = context;
            _configuration = configuration;
            from = _configuration["EmailConfiguration:From"].ToString();
            server = _configuration["EmailConfiguration:Server"].ToString();
            port = Int32.Parse(_configuration["EmailConfiguration:Port"]);
        }

        /// <summary>
        /// Method to sending emails
        /// </summary>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="mailCategory"></param>
        /// <param name="mailId"></param>
        /// <returns></returns>
        public async Task SendEmailMessageAsync(string to, string cc, string subject, string body, string mailCategory, string headerTitle = "", int mailId = 0)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Intel Application Portfolio Management", "intel.application.portfolio.management@intel.com"));
            string sendMailMode = GetSystemconfiguration("send_mail_mode");
            string sendMailDebugAddress = GetSystemconfiguration("send_mail_debug_addresses");
            string authGenerator = GetSystemconfiguration("send_mail_auth_generator");
            string authKey = EncryptionHelper.Decrypt(GetSystemconfiguration("send_mail_auth_key"));
            //Call different email template methods only for Social Application
            if (mailCategory == Constants.STR_MAIL_SEND_CATEGORY_SOCIAL_APPLICATION_NOTIFICATION)
            {
                body = GetEmailStyles() + GetHREmailHeader(headerTitle) + body + GetHREmailFooter();
            }
            //Common header and footer template
            else
            {
                body = GetEmailStyles() + GetEmailHeader(headerTitle) + body + GetEmailFooter();
            }

            //Null check of email address to avoid error
            to = string.IsNullOrEmpty(to) ? "" : to;
            cc = string.IsNullOrEmpty(cc) ? "" : cc;

            if (sendMailMode.ToUpper() != "PRODUCTION")
            {
                string originalMailRecipients = "to:" + to.ToString() + " cc:" + cc.ToString();
                subject = "DEBUG TEST - PLEASE DISREGARD: " + subject;
                body = body + "<div style='color:red'>Would have mailed:" + originalMailRecipients + " </div>";
                to = sendMailDebugAddress;
                cc = string.Empty;
            }

            List<string> toMail = to.ToString().Split(';').ToList();
                message.To.AddRange(toMail.Where(x => !string.IsNullOrEmpty(x)).Select(x => new MailboxAddress(x)));
                List<string> ccMail = cc.ToString().Split(';').ToList();
                message.Cc.AddRange(ccMail.Where(x => !string.IsNullOrEmpty(x)).Select(x => new MailboxAddress(x)));
                message.Subject = subject;
           
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            if (message.To.Count > 0 || message.Cc.Count > 0)
            {
                using (var client = new SmtpClient())
                {
                    try
                    {
                        await client.ConnectAsync(server, port, SecureSocketOptions.StartTls);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        await client.AuthenticateAsync(authGenerator, authKey);
                        await client.SendAsync(message);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        await client.DisconnectAsync(true);
                        client.Dispose();
                    }
                }
            }
            //Add or Update Mail Log
            //var result = await AddMailLog(to, cc, subject, body, mailCategory, mailId);
        }

        /// <summary>
        /// Method to send DataGovernance report with attachment
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public async Task SendEmailDataGovernanceReportAsync(string to, string subject, string body, List<string> csvData)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Intel Application Portfolio Management", "intel.application.portfolio.management@intel.com"));
            string sendMailMode = GetSystemconfiguration("send_mail_mode");
            string sendMailDebugAddress = GetSystemconfiguration("send_mail_debug_addresses");
            string authGenerator = GetSystemconfiguration("send_mail_auth_generator");
            string authKey = EncryptionHelper.Decrypt(GetSystemconfiguration("send_mail_auth_key"));            

            if (sendMailMode.ToUpper() != "PRODUCTION")
            {
                string originalMailRecipients = "to:" + to.ToString();
                List<MailboxAddress> debugTo = new List<MailboxAddress>();
                List<string> debugMail = sendMailDebugAddress.ToString().Split(';').ToList();
                foreach (var item in debugMail)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        debugTo.Add(MailboxAddress.Parse(item));
                    }
                }
                message.To.AddRange(debugTo);
                message.Subject = "DEBUG TEST - PLEASE DISREGARD: " + subject;


                body = body + "<div style='color:red'>Would have mailed:" + originalMailRecipients + " </div>";
            }
            else
            {
                List<string> toMail = to.ToString().Split(';').ToList();
                message.To.AddRange(toMail.Where(x => !string.IsNullOrEmpty(x)).Select(x => new MailboxAddress(x)));
                message.Subject = subject;
            }             

            // Run time create File Attachment to Email (Without created Physical File)
            var csvfilename = "Data_Governance_Report_" + DateTime.UtcNow.ToString("MMddyyyy") + ".csv";
            byte[] dataAsBytes = csvData.SelectMany(s =>System.Text.Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();            

            var attachments1 = new List<MimeEntity>
            {
                MimeEntity.Load(new ContentType("application", "csv"), new MemoryStream(dataAsBytes))
            };
            var builder = new BodyBuilder();
            builder.Attachments.Add(csvfilename, dataAsBytes, new ContentType("application", "csv"));              

            var multipart = new Multipart("mixed");
            multipart.Add(new TextPart(MimeKit.Text.TextFormat.Html) { Text = body });
            multipart.Add(builder.ToMessageBody());
            message.Body = multipart;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(server, port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(authGenerator, authKey);
                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
            //Add or Update Mail Log
            //var result = await AddMailLog(to, "", subject, body, "DataGovernanceReport", 0);
        }

        /// <summary>
        /// Method to return system configuration
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSystemconfiguration(string key)
        {
            try
            {
                key = key.ToUpper();
                return _context.SystemConfigurations.Where(c => c.ConfigurationKey.ToUpper() == key && c.ActiveInd == CommonUtility.Constants.STR_YES).Select(c => c.ConfigurationValue).FirstOrDefault();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Return Mail Header info
        /// </summary>
        /// <returns></returns>
        public string GetEmailHeader(string headerTitle)
        {
            try
            {
                var builder = new BodyBuilder();
                using (StreamReader SourceReader = File.OpenText("EmailTemplates/emailHeader.html"))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                string htmlBody = string.Format(builder.HtmlBody, headerTitle);
                return htmlBody;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Return Mail footer information
        /// </summary>
        /// <returns></returns>
        public string GetEmailFooter()
        {
            try
            {
                var builder = new BodyBuilder();
                using (StreamReader SourceReader = File.OpenText("EmailTemplates/emailFooter.html"))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                string environmentRootURL = GetSystemconfiguration("environment_root_url");
                string messageBody = string.Format(builder.HtmlBody, environmentRootURL);
                return messageBody;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Return Mail Header info for HR mails
        /// </summary>
        /// <returns></returns>
        public string GetHREmailHeader(string headerTitle)
        {
            try
            {
                var builder = new BodyBuilder();
                using (StreamReader SourceReader = File.OpenText("EmailTemplates/hrEmailHeader.html"))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                string htmlBody = string.Format(builder.HtmlBody, headerTitle);
                return htmlBody;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///Return Mail Footer info for HR mails
        ///</summary>
        ///<returns></returns>
        public string GetHREmailFooter()
        {
            try
            {
                var builder = new BodyBuilder();
                using (StreamReader SourceReader = File.OpenText("EmailTemplates/hrEmailFooter.html"))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                return builder.HtmlBody;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Return Mail Styles CSS
        /// </summary>
        /// <returns></returns>
        public string GetEmailStyles()
        {
            try
            {
                var builder = new BodyBuilder();
                using (StreamReader SourceReader = File.OpenText("EmailTemplates/styles.html"))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                return builder.HtmlBody;
            }
            catch
            {
                return string.Empty;
            }
        }

        /*
        public async Task<string> AddMailLog(string to, string cc, string subject, string body, string categoryNm, int mailId=0)
        {
            try
            {
                if (mailId > 0)
                {
                    MailSendLog mailSendLog = await _context.MailSendLog.Where(l => l.MailId == mailId).FirstOrDefaultAsync();
                    //Update Log values
                    mailSendLog.MailTo = to;
                    mailSendLog.MailCc = cc;
                    mailSendLog.MailSubject = subject;
                    mailSendLog.MailBody = body;
                    mailSendLog.MailSendDtm = DateTime.Now;
                    _context.Update(mailSendLog);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    MailSendLog mailLog = new MailSendLog()
                    {
                        MailBcc = "",
                        MailTo = to,
                        MailCc = cc,
                        MailSubject = subject,
                        MailBody = body,
                        MailBodyFormat = "HTML",
                        MailCategoryNm = categoryNm,
                        MailFrom = "",
                        MailSendDtm = DateTime.Now
                    };
                    _context.MailSendLog.Add(mailLog);
                    await _context.SaveChangesAsync();
                }
                return "Success";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        */
    }
}
