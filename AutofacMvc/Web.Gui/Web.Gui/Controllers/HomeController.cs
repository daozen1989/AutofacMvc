using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Gui.Models;
using Web.Interfaces;

namespace Web.Gui.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        public async Task<ActionResult> Index()
        {
            var user = await _customerService.GetStringCheckDI();
            return View("index", new UserViewModel { UserList = user.ToList()});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}