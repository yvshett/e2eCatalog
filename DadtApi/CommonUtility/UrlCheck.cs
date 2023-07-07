using System;
using System.Reflection;
using System.Net.NetworkInformation;

namespace DadtApi.CommonUtility
{
    public interface IUrlCheck
    {
        int ValidateUrl(string url);
    }

    public class UrlCheck : IUrlCheck
    {

        private readonly ILog _log;

        public UrlCheck(ILog log)
        {
            _log = log;
        }

        public int ValidateUrl(string url)
        {
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
            try
            {
                Uri uri = new Uri(url);
                string pingurl = string.Format("{0}", uri.Host);
                string host = pingurl;
                Ping p = new Ping();
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return 1;
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
                return 0;
            }
            return 1;
        }

    }
}
