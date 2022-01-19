using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using StoreWebApp.Models;
using StoreWebApp.Service;

namespace StoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string key = "products";
            var ProductData= await Services.GetPartialProductListAsync();
            Random rnd = new Random();
            TempData["trendingData"] = ProductData.OrderBy(item => rnd.Next()).Take(4);
            TempData["moreToExploreData"] = ProductData.OrderBy(item => rnd.Next()).Take(6);

            var Products = await Services.GetDataFromAPIAsync(key);
            return View(Products);
        }

        public ActionResult TrimDesc(List<ProductModel> product)
        {
            for (int i = 0; i < product.Count; i++)
            {
                product[i].Description = product[i].Description.Length <= 12 ? product[i].Description : product[i].Description.Substring(0, 12);
            }

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