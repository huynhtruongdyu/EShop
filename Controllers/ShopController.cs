using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}