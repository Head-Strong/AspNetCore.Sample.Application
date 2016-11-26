using System.Threading.Tasks;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.Domains;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Core.Web.App.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerService"></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Customer customer)
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
            var result = _customerService.GetCustomers();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
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
        public async Task<IActionResult> GetAsync()
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(result);
        }
    }
}
