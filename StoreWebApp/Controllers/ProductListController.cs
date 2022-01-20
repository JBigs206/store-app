using System.Web.Mvc;
using System.Threading.Tasks;
using StoreWebApp.Service;

namespace StoreWebApp.Controllers
{
    public class ProductListController : Controller
    {
        // GET: ProductList
        public async Task<ActionResult> Index()
        {
            var Products = await Services.GetDataFromAPIAsync();
            return View(Products);
        }
    }
}