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
        private IBookCategoriesService _bookCategoriesService;

        public HomeController(ICustomerService customerService, IBookCategoriesService bookCategoriesService)
        {
            this._customerService = customerService;
            this._bookCategoriesService = bookCategoriesService;
        }
        public async Task<ActionResult> Index()
        {
            var bookCategories = await _bookCategoriesService.GetAllBookCategory();
            return View("index", new BookCategoriesViewModel { BookCategoryList = bookCategories.ToList()});
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