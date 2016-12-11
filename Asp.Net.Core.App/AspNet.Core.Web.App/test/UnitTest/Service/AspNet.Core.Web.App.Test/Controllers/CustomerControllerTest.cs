using System.Collections.Generic;
using AspNet.Core.TestData;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.App.Controllers;
using AspNet.Core.Web.Domains;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNet.Core.Web.App.Test.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        private Mock<ICustomerService> _customerServiceMock;
        private CustomerController _customerController;
        private Serilog.ILogger _logger;

        [TestInitialize]
        public void Setup()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _logger = new Serilog.LoggerConfiguration().CreateLogger();
            
            _customerController = new CustomerController(_customerServiceMock.Object, _logger);
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            _customerServiceMock.Setup(x => x.GetCustomers()).Returns(new List<Customer>());

            var actualResult = _customerController.Get();

            actualResult.Should().NotBeNull();
            _customerServiceMock.Verify(x => x.GetCustomers());
        }

        [TestMethod]
        public void Get_All_Customers_Async()
        {
            _customerServiceMock.Setup(x => x.GetCustomersAsync()).ReturnsAsync(new List<Customer>());

            var actualResult = _customerController.GetAsync();

            actualResult.Should().NotBeNull();
            _customerServiceMock.Verify(x => x.GetCustomersAsync());
        }

        [TestMethod]
        public void Save_Customers()
        {
            var customer = CustomerData.PrepareCustomer();

            _customerServiceMock.Setup(x => x.SaveCustomer(customer)).Returns(customer);

            var actualResult = _customerController.Post(customer);

            actualResult.Should().NotBeNull();
            _customerServiceMock.Verify(x => x.SaveCustomer(customer));
        }

        [TestMethod]
        public void Save_Customers_Async()
        {
            var customer = CustomerData.PrepareCustomer();

            _customerServiceMock.Setup(x => x.SaveCustomerAsync(customer)).ReturnsAsync(customer);

            var actualResult = _customerController.PostAsync(customer);

            actualResult.Should().NotBeNull();
            _customerServiceMock.Verify(x => x.SaveCustomerAsync(customer));
        }

        [TestCleanup]
        public void TearDown()
        {
            _customerServiceMock = null;
            _customerController = null;
        }
    }
}
