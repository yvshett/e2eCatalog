using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DadtApi_MSTest
{
    [TestClass]
    public class ApiTests
    {
        private HttpClient _httpClient;
        public ApiTests()
        {
            //var decrypted = DadtApi.CommonUtility.EncryptionHelper.EncryptString("server=postgres5931-lb-fm-in.dbaas.intel.com;port=5433;database=e2e;uid=e2e_so;password=9S22a78Md2966Dc; command timeout=120;", DadtApi.CommonUtility.Constants.STR_ENCRYPT_DECRYPT_KEY);
            //var enc = DadtApi.CommonUtility.EncryptionHelper.Decrypt(decrypted);
            //var webAppFactory = new WebApplicationFactory<Program>();
            
            //_httpClient = webAppFactory.CreateDefaultClient();

        }
        [TestMethod]
        public async Task Test_Get_Supplier()
        {
            var decrypted = DadtApi.CommonUtility.EncryptionHelper.EncryptString("server=postgres5931-lb-fm-in.dbaas.intel.com;port=5433;database=e2e;uid=e2e_so;password=9S22a78Md2966Dc; command timeout=120;", "SUFQTUAyMDgwOA==");
            var response = await _httpClient.GetAsync("api/Suppliers/Intel");
            //var stringResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}