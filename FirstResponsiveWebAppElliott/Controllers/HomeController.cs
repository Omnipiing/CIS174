using FirstResponsiveWebAppElliott.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppElliott.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.UserName = null;
            ViewBag.Age = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AgeFinderModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.UserName = model.UserName;
                ViewBag.Age = model.AgeThisYear();
            }
            else
            {
                ViewBag.UserName = null;
                ViewBag.Age = 0;
            }
            
            return View(model);
        }

    }
}
