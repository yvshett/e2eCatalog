using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DadtApi.Models;
using System;
using System.Net.Http.Json;
using System.Text;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace DadtApi_MSTest
{
    [TestClass]
    public class ApplicationToolTipsTestCases
    {
        private HttpClient _httpClient;
        public ApplicationToolTipsTestCases()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
         public async Task Test1_GetApplicationToolTip()
         {
             var response = await _httpClient.GetAsync("api/ApplicationToolTips");
             response.EnsureSuccessStatusCode();
             Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
         }
        /*
        [TestMethod]
        public async Task Test2_PostApplicationToolTip()
        {
            ApplicationToolTip _ApplicationToolTip = new ApplicationToolTip();
            _ApplicationToolTip.AttributeNm = "Testing1";
            _ApplicationToolTip.AtrributeHelpTxt = "Testing test cases1";
            _ApplicationToolTip.ActiveInd = "N";
            _ApplicationToolTip.CreateAgentId = "11933688";
            _ApplicationToolTip.CreateDtm = DateTime.Now;
            _ApplicationToolTip.ChangeAgentId = "11933688";
            _ApplicationToolTip.ChangeDtm = DateTime.Now;

            var ParamJson = Newtonsoft.Json.JsonConvert.SerializeObject(_ApplicationToolTip);
            var content = new StringContent(ParamJson,Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/ApplicationToolTips", content);
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsNotNull(response);
        }

        
        [TestMethod]
        public async Task Test3_PutApplicationToolTip3()
        {
            int id = 60;
            ApplicationToolTip _ApplicationToolTip = new ApplicationToolTip();
            _ApplicationToolTip.ApplicationToolTipId = 60;
            _ApplicationToolTip.AttributeNm = "Testing1";
            _ApplicationToolTip.AtrributeHelpTxt = "Testing test cases";
            _ApplicationToolTip.ActiveInd = "N";
            _ApplicationToolTip.CreateAgentId = "11933688";
            _ApplicationToolTip.CreateDtm = DateTime.Now;
            _ApplicationToolTip.ChangeAgentId = "11933688";
            _ApplicationToolTip.ChangeDtm = DateTime.Now;

            var ParamJson = Newtonsoft.Json.JsonConvert.SerializeObject(_ApplicationToolTip);
            var content = new StringContent($"{ ParamJson}", Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/ApplicationToolTips/"+id, content);
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsNotNull(response);
        }
        */
        [TestMethod]
        public async Task Test4_DeleteApplicationToolTip4()
        {
            int id = 60;

            var response = await _httpClient.DeleteAsync("api/ApplicationToolTips/" + id);
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsNotNull(response);
        }
    }
}
