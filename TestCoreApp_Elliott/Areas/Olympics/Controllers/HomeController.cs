using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApp_Elliott.Areas.Olympics.Models;
using TestCoreApp_Elliott.Models.OlympicGames;

namespace TestCoreApp_Elliott.Controllers.OlympicGames
{
	[Area("Olympics")]
	public class HomeController : Controller
	{
		private OlympicsContext context;

		public HomeController(OlympicsContext ctx)
		{
			context = ctx;
		}

		public ViewResult Index(string activeCat = "all", string activeGame = "all")
		{
			var session = new OlympicSession(HttpContext.Session);
			session.SetActiveCat(activeCat);
			session.SetActiveGame(activeGame);

			var model = new OlympicsListViewModel
			{
				ActiveCat = activeCat,
				ActiveGame = activeGame,
				Categories = context.Categories.ToList(),
				Games = context.Games.ToList(),
			};

			//get countries - filter by categories and games
			IQueryable<Country> query = context.Countries;
			if (activeCat != "all")
				query = query.Where(t => t.Category.CategoryId.ToLower() == activeCat.ToLower());
			if (activeGame != "all")
				query = query.Where(t => t.Game.GameId.ToLower() == activeGame.ToLower());

			//pass countries to view as model
			model.Countries = query.ToList();

			return View(model);
		}

		public IActionResult Details(string id)
		{
			var session = new OlympicSession(HttpContext.Session);
			var model = new CountryViewModel
			{
				Country = context.Countries
					.Include(t => t.Category)
					.Include(t => t.Game)
					.FirstOrDefault(t => t.CountryID == id),
				ActiveCat = session.GetActiveCat(),
				ActiveGame = session.GetActiveGame()
			};
			return View(model);
		}

		[HttpPost]
		public RedirectToActionResult Add(CountryViewModel data)
		{
			data.Country = context.Countries
				.Include(t => t.Category)
				.Include(t => t.Game)
				.Where(t => t.CountryID == data.Country.CountryID)
				.FirstOrDefault();

			var session = new OlympicSession(HttpContext.Session);
			var teams = session.GetMyCountries();
			teams.Add(data.Country);
			session.SetMyCountries(teams);

			TempData["message"] = $"{data.Country.Name} added to your favorites";

			return RedirectToAction("Index",
				new
				{
					ActiveConf = session.GetActiveCat(),
					ActiveDiv = session.GetActiveGame()
				});
		}
	}
}
