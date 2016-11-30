using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNet.Core.Web.App.IntegrationTest.Controller
{
    [TestClass]
    public class CustomerControllerTest
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var response = _client.GetAsync("/api/Customer");

            //response.EnsureSuccessStatusCode();

            var responseString = response.Result.Content;

            // Assert
        }

        [TestCleanup]
        public void Clean()
        {
            _server?.Dispose();
            _client?.Dispose();
        }
    }
}
