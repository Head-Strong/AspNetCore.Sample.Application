﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.Domains;
using CustomLogger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Core.Web.App.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize(Roles = "CustomerDetails")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly Serilog.ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        /// <param name="logger"></param>
        public CustomerController(ICustomerService customerService, Serilog.ILogger logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            var result = _customerService.SaveCustomer(customer);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.CustomInformation(user: "Aditya", enviornment: "Dev", informationMessage: "Data Added Successfully");
            _logger.CustomError(errorMessage: "Data Critical Added Successfully");
            _logger.CustomFatal(fatalMessage: "Data Error Added Successfully");

            var result = _customerService.GetCustomers();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/postasync")]
        public async Task<IActionResult> PostAsync(Customer customer)
        {
            var result = await _customerService.SaveCustomerAsync(customer);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/getasync")]
        [Produces("application/json", Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(result);
        }
    }
}
