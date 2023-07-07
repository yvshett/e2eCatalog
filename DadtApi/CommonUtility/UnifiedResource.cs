using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadtApi.CommonUtility
{
    public static class UnifiedResource
    {
        public static bool IsValidUrl(string uriName)
        {
            Uri uriResult;
            bool result = false;
            try
            {
                result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
