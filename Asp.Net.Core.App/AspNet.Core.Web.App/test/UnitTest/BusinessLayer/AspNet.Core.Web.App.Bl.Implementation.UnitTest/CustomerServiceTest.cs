using System.Collections.Generic;
using AspNet.Core.TestData;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using Serilog;
using Serilog.Core;

namespace AspNet.Core.Web.App.Bl.Implementation.Test
{
    [TestClass]
    public class CustomerServiceTest
    {
        private Mock<IRepository<Customer>> _customerRepositoryMock;
        private ICustomerService _customerService;
        private ILogger _logger;

        [TestInitialize]
        public void Setup()
        {
            _customerRepositoryMock = new Mock<IRepository<Customer>>();
            _logger = new LoggerConfiguration().CreateLogger();
            _customerService = new CustomerService(_customerRepositoryMock.Object, _logger);
        }

        [TestMethod]
        public void Get_All_Customers_Service()
        {
            _customerRepositoryMock.Setup(x => x.GetEntities()).Returns(new List<Customer>());

            var actualResult = _customerService.GetCustomers();

            actualResult.Should().NotBeNull();
            _customerRepositoryMock.Verify(x => x.GetEntities());
        }

        [TestMethod]
        public void Get_All_Customers_Service__Async()
        {
            _customerRepositoryMock.Setup(x => x.GetEntitiesAsync()).ReturnsAsync(new List<Customer>());

            var actualResult = _customerService.GetCustomersAsync();

            actualResult.Should().NotBeNull();
            _customerRepositoryMock.Verify(x => x.GetEntitiesAsync());
        }

        [TestMethod]
        public void Save_Customers_Service()
        {
            var customer = CustomerData.PrepareCustomer();

            _customerRepositoryMock.Setup(x => x.Save(customer)).Returns(customer);

            var actualResult = _customerService.SaveCustomer(customer);

            actualResult.Should().NotBeNull();
            _customerRepositoryMock.Verify(x => x.Save(customer));
        }

        [TestMethod]
        public void Save_Customers_Service_Async()
        {
            var customer = CustomerData.PrepareCustomer();

            _customerRepositoryMock.Setup(x => x.SaveAsync(customer)).ReturnsAsync(customer);

            var actualResult = _customerService.SaveCustomerAsync(customer);

            actualResult.Should().NotBeNull();
            _customerRepositoryMock.Verify(x => x.SaveAsync(customer));
        }

        [TestCleanup]
        public void TearDown()
        {
            _customerRepositoryMock = null;
            _customerService = null;
        }
    }
}
