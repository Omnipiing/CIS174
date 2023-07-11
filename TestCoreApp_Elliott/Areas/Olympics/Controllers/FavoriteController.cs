using Microsoft.AspNetCore.Mvc;
using TestCoreApp_Elliott.Areas.Olympics.Models;
using TestCoreApp_Elliott.Models.OlympicGames;

namespace TestCoreApp_Elliott.Areas.Olympics.Controllers
{
    [Area("Olympics")]
    public class FavoriteController : Controller
	{
		[HttpGet]
		public ViewResult Index()
		{
			var session = new OlympicSession(HttpContext.Session);
			var model = new OlympicsListViewModel
			{
				ActiveCat = session.GetActiveCat(),
				ActiveGame = session.GetActiveGame(),
				Countries = session.GetMyCountries()
			};

			return View(model);
		}

		[HttpPost]
		public RedirectToActionResult Delete()
		{
			var session = new OlympicSession(HttpContext.Session);
			var cookies = new OlympicCookies(Response.Cookies);

			session.RemoveMyCountries();
			cookies.RemoveMyCountryIds();

			TempData["message"] = "Favorite countries cleared";

			return RedirectToAction("Index", "Home",
				new
				{
					ActiveCat = session.GetActiveCat(),
					ActiveGame = session.GetActiveGame()
				});
		}
	}
}
