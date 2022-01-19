using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using StoreWebApp.Service;

namespace StoreWebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public async Task<ActionResult> Index(int Id = 0)
        {
            string key = "products";
            var ProductData = await Services.GetPartialProductListAsync();
            Random rnd = new Random();
            TempData["moreToExploreData"] = ProductData.OrderBy(item => rnd.Next()).Take(6);
            var Product = await Services.GetProductByIdAsync(key,Id);
            return View(Product);
        }
    }
}