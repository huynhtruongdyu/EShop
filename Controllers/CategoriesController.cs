using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class CategoriesController(ICatalogService catalogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await catalogService.GetSFCategoriesAsync();
            return View(categories);
        }
    }
}
