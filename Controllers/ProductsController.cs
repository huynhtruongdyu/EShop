using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}