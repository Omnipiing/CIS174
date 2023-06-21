using Microsoft.AspNetCore.Mvc;
using MultiPageWebAppElliott.Models;

namespace MultiPageWebAppElliott.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ContactContext context;

        public HomeController(ILogger<HomeController> logger, ContactContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts.OrderBy(m  => m.ContactName).ToList();
            return View(contacts);
        }
    }
}
