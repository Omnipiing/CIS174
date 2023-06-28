using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MDPwebApp.Models;

namespace MDPwebApp.Areas.Approver.Controllers
{
    [Area("Approver")]
    public class HomeController : Controller
    {
        private RequestContext context { get; set; }

        public HomeController(RequestContext ctx) => context = ctx;

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult Index()
        {
            var requests = context.Requests.OrderBy(r => r.MaterialNumber).ToList();
            return View(requests);
        }

        [Route("[area]/[controller]s/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("[area]/[controller]s/terms-of-service")]
        public IActionResult TermsOfService()
        {
            return View();
        }
    }
}
