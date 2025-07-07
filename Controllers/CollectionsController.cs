using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    public class CollectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}