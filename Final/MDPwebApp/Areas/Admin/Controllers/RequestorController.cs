using Microsoft.AspNetCore.Mvc;
using MDPwebApp.Models;
using MDPwebApp.Migrations;

namespace MDPwebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestorController : Controller
    {
        private RequestContext context { get; set; }    

        public RequestorController(RequestContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Requestor());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var request = context.Requests.Find(id);
            return View(request);
        }

        [HttpPost]
        public IActionResult Edit(Requestor request)
        {
            if (ModelState.IsValid)
            {
                if (request.requestId == 0)
                {
                    context.Requests.Add(request);
                }
                else // Edit options
                {

                    context.Requests.Update(request);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (request.requestId == 0) ? "Add" : "Edit";
                return View(request);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var request = context.Requests.Find(id);
            return View(request);
        }

        [HttpPost]
        public IActionResult Delete(Requestor request)
        {
            context.Requests.Remove(request);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
