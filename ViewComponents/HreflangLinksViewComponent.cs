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

            // Remove the current culture segment from the path
            var currentCulture = System.Globalization.CultureInfo.CurrentUICulture.Name;
            string pathWithoutCulture = path;

            if (!string.IsNullOrEmpty(path) && path.StartsWith(currentCulture, StringComparison.OrdinalIgnoreCase))
            {
                pathWithoutCulture = path.Substring(currentCulture.Length).TrimStart('/');
            }

            var hreflangs = LocalizationConstants.SupportedCultures
                .Select(lang => new HreflangLinkViewModel(
                    lang,
                    $"{scheme}://{host}/{lang}/{pathWithoutCulture}"
                ))
                .ToList();

            // Optionally add x-default
            hreflangs.Insert(0, new HreflangLinkViewModel("x-default", $"{scheme}://{host}/{pathWithoutCulture}"));

            return View(hreflangs);
        }
    }
}