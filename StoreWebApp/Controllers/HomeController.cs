using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using StoreWebApp.Service;

namespace StoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var ProductData= await Services.GetDataFromAPIAsync();
            Random rnd = new Random();
            TempData["trendingData"] = ProductData.OrderBy(item => rnd.Next()).Take(4);
            TempData["moreToExploreData"] = ProductData.OrderBy(item => rnd.Next()).Take(6);
            return View();
        }

        public ActionResult About()
        {
            //TODO
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //TODO
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}