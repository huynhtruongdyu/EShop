namespace EShop.Controllers
{
    [Route("")]
    public class SeoController : Controller
    {
        [HttpGet("robots.txt")]
        public IActionResult Robot()
        {
            // You can customize the content as needed
            var robotsContent = "User-agent: *\nDisallow:";
            return Content(robotsContent, MediaTypeNames.Text.Plain);
        }

        [HttpGet("sitemap.xml")]
        public IActionResult Sitemap()
        {
            var urls = new[]
            {
                "https://example.com/",
                "https://example.com/about",
                "https://example.com/contact"
            };

            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var xml = new XDocument(
                new XElement(ns + "urlset",
                    urls.Select(url =>
                        new XElement(ns + "url",
                            new XElement(ns + "loc", url),
                            new XElement(ns + "changefreq", "weekly"),
                            new XElement(ns + "priority", "0.8")
                        )
                    )
                )
            );

            return Content(xml.ToString(), MediaTypeNames.Application.Xml);
        }
    }
}