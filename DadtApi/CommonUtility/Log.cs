using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace DadtApi.CommonUtility
{
    public interface ILog
    {
        void LogSet(LogModel logModel);
        void LogEntry(string stepName, string stepDetail, string logType, string startTime, string endTime);
        string GetLoginId();
        string GetDb();
        string GetDbHost();
        string DetermineClientSystemName(string IP);
    }

    public class Log : ILog
    {

        public IConfiguration _configuration { get; }
        private readonly IActionContextAccessor _actionContextAccessor;
        public string token; string environment; string serviceURL; string IapId; string appName; string org;
        public string connStr;

        public Log(IConfiguration configuration, IActionContextAccessor actionContextAccessor)
        {
            _configuration = configuration;
            _actionContextAccessor = actionContextAccessor;
            token = _configuration["CLFLogging:Token"].ToString();
            environment = _configuration["CLFLogging:LogEnvironmentForKibana"].ToString();
            serviceURL = _configuration["CLFLogging:CLFServiceUrl"].ToString();
            IapId = _configuration["CLFLogging:IapId"];
            appName = _configuration["CLFLogging:AppName"].ToString();
            org = _configuration["CLFLogging:AppAcronym"].ToString();
            connStr = EncryptionHelper.Decrypt(_configuration["ConnectionStrings:DADTConnection"]);
        }
       
        public StringBuilder sbOverallLogs = new StringBuilder();


        public string GetLoginId()
        {
            try
            {
                if (_actionContextAccessor.ActionContext != null && _actionContextAccessor.ActionContext.HttpContext != null && _actionContextAccessor.ActionContext.HttpContext.User.Identity.Name != null)
                    return _actionContextAccessor.ActionContext.HttpContext.User.Identity.Name;
                else
                    return "System";
            }
            catch (Exception)
            {
                return "System";
            }
            
        }

        public string GetDb()
        {
            var dbName = string.Empty;
            try
            {
                var arraySplit = connStr.Split(';');
                dbName = arraySplit.Where(p => p.Contains("database=")).Select(p => p.Replace("database=", "")).FirstOrDefault();
            }
            catch { }
            return dbName;
        }

        public string GetDbHost()
        {
            var dbName = string.Empty;
            try
            {
                var arraySplit = connStr.Split(';');
                dbName = arraySplit.Where(p => p.Contains("server=")).Select(p => p.Replace("server=", "")).FirstOrDefault();
            }
            catch { }
            return dbName;
        }

        public static string GetClientIPAddress(HttpContext context)
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
            {
                ip = context.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }

        public string DetermineClientSystemName(string IP)
        {
            try
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                return compName.First();
            }
            catch
            {
                return "NA";
            }
        }

        public void LogSet(LogModel logModel)
        {
            try
            {
                var _genericServiceUrl = serviceURL;
                var _token = token;
                var json = string.Empty;


                json = "[" + JsonConvert.SerializeObject(logModel) + "]";
                var result = MakeAsyncLogRequest(_genericServiceUrl, _token, json);

                //in sync mode check async task status
                Task.WaitAll(result);
            }
            catch (Exception)
            {
                
            }
        }


        public void LogEntry(string stepName, string stepDetail, string logType, string startTime, string endTime)
        {
            try
            {
                var clientIpAddress = _actionContextAccessor.ActionContext != null ? GetClientIPAddress(_actionContextAccessor.ActionContext.HttpContext) : "Unknown";// _actionContextAccessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();// HttpContext.Current.Request.UserHostAddress;
                var clientSystemName = DetermineClientSystemName(clientIpAddress);
                var dbName = GetDb();
                var dbHost = GetDbHost();
                
                LogModel logModel = new LogModel();
                logModel.MachineAccount = GetLoginId();
                logModel.LogCategory = CommonUtility.Constants.STR_LOG_CATEGORY_API;
                logModel.StepName = stepName;
                logModel.StepDetail = stepDetail;
                logModel.DBName = dbName;
                logModel.SchemaName = dbHost;
                logModel.LogType = logType;
                logModel.ServerMachineIP = clientIpAddress;
                logModel.ServerMachineName = clientSystemName;
                logModel.StartTime = startTime;
                logModel.EndTime = endTime;
                logModel.SessionId = Guid.NewGuid().ToString();
                logModel.Custom = new Custom() {str_org = org, str_dadt_environment = environment };

                var json = "[" + JsonConvert.SerializeObject(logModel) + "]";
                var result = MakeAsyncLogRequest(serviceURL, token, json);

                ////in sync mode check async task status
                Task.WaitAll(result);
            }
            catch (Exception)
            {

            }
        }

        //async task
        /// <summary>
        /// Prepare Async Log Request 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="jsonPostData"></param>
        /// <returns></returns>
        public Task MakeAsyncLogRequest(string url, string token, string jsonPostData)//, string contentType)
        {
            Task<WebResponse> task = null;
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Headers["Authorization"] = "Bearer " + token;
                request.ContentType = "application/json";
                request.Method = WebRequestMethods.Http.Post;
                request.Timeout = 20000;

                request.Proxy = null;

                byte[] data = Encoding.ASCII.GetBytes(jsonPostData);
                request.ContentLength = data.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                task = Task.Factory.FromAsync(
                    request.BeginGetResponse,
                    asyncResult => request.EndGetResponse(asyncResult), (object)null);
                return task.ContinueWith(t => LogCompletedEvent(t.Result));
            }
            catch (System.Net.WebException)
            {

            }
            catch (Exception e)
            {
                var m = e.Message;
            }
            return task;
        }

        /// <summary>
        /// Read the response and seee whether logging is successfull
        /// </summary>
        /// <param name="response"></param>
        private void LogCompletedEvent(WebResponse response)
        {

        }

    }
}
