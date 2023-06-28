using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MDPwebApp.Models;

namespace MDPwebApp.Controllers
{
    public class HomeController : Controller
    {
        private RequestContext context { get; set; }

        public HomeController(RequestContext ctx) => context = ctx;

        [Route("/")]
        public IActionResult Index()
        {
            var requests = context.Requests.OrderBy(r => r.MaterialNumber).ToList();
            return View(requests);
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("terms-of-service")]
        public IActionResult TermsOfService()
        {
            return View();
        }
    }
}
