using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListElliott.Models;

namespace MovieListElliott.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext context;

        public HomeController(ILogger<HomeController> logger, MovieContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index()
        {
            //var movies = context.Movies.OrderBy(m => m.Name).ToList();
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
