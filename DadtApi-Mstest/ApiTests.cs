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
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();

        }
        [TestMethod]
        public async Task Test_Get_Supplier()
        {            
            var response = await _httpClient.GetAsync("api/Suppliers/Intel");
            //var stringResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}