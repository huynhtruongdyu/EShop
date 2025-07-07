namespace EShop.ViewComponents
{
    public class HreflangLinksViewComponent(IHttpContextAccessor httpContextAccessor) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var scheme = httpContextAccessor!.HttpContext!.Request.Scheme;
            var request = httpContextAccessor!.HttpContext!.Request;
            var host = request.Host.Value;
            var path = request.Path.Value?.TrimStart('/');

            var hreflangs = LocalizationConstants.SupportedCultures.Select(lang => new HreflangLinkViewModel(lang, $"{scheme}://{host}/{lang}/{path}")).ToList();

            // Optionally add x-default
            hreflangs.Insert(0, new HreflangLinkViewModel("x-default", $"{scheme}://{host}/{path}"));

            return View(hreflangs);
        }
    }
}