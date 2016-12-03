using System;
using System.Web.Mvc;
using MvcApp.Client.Filters;
using OAuth.Client;

namespace MvcApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOauthClient _ouathClient;

        public HomeController()
        {
            _ouathClient = new OauthClient();    
        }


        [CustomAuthentication]
        // GET: Home
        public ActionResult Index()
        {
            var accessToken = Convert.ToString(RouteData.Values["AccessToken"]);

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return Content("Access token empty");
            }
            else
            {
                var response = _ouathClient.GetCustomers(accessToken);
                return View(response);
            }            
        }
    }
}