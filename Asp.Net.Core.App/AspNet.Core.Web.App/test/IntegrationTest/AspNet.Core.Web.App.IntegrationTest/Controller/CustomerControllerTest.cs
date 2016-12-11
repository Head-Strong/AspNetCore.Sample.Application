using System.Collections.Generic;
using System.Net.Http;
using AspNet.Core.Web.Domains;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
        public void Get_All_Customers_Integration_Test()
        {
            var response = _client.GetAsync("/api/Customer");

            //response.EnsureSuccessStatusCode();

            var responseString = response.Result.Content.ReadAsStringAsync().Result;

            // Assert
            responseString.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Save_Customer_Then_Check_Save_Integration_Test()
        {
            var customer = new StringContent(JsonConvert.SerializeObject(PrepareCustomer()));

            //_client.DefaultRequestHeaders.Clear();

            //_client.DefaultRequestHeaders.Add("content-type", "application/json");

            var response = _client.PostAsync("/api/Customer", customer);

            //response.EnsureSuccessStatusCode();

            var responseString = response.Result.Content.ReadAsStringAsync().Result;

            // Assert
            responseString.Should().NotBeNullOrEmpty();

            response = _client.GetAsync("/api/Customer");

            //response.EnsureSuccessStatusCode();

            responseString = response.Result.Content.ReadAsStringAsync().Result;
        }

        private static Customer PrepareCustomer()
        {
            var customer = new Customer
            {
                Id = 0,
                LastName = "Sharma",
                Name = "Kapil",
                Addresses = new List<Address>
                {
                    new Address()
                    {
                        CustomerId = 0,
                        Id = 0,
                        Pin = "423123"
                    },
                    new Address()
                    {
                        CustomerId = 0,
                        Id = 0,
                        Pin = "423124"
                    }
                }
            };

            return customer;
        }


        [TestCleanup]
        public void Clean()
        {
            _server?.Dispose();
            _client?.Dispose();
        }
    }
}
