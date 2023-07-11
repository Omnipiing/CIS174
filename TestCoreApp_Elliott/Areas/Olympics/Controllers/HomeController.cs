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

		public ViewResult Index(OlympicsListViewModel model)
		{
			model.Categories = context.Categories.ToList();
			model.Games = context.Games.ToList();

			var session = new OlympicSession(HttpContext.Session);
			session.SetActiveCat(model.ActiveCat);
			session.SetActiveGame(model.ActiveGame);

            // if no count value in session, use data in cookie to restore fave teams in session 
            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new OlympicCookies(HttpContext.Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                    mycountries = context.Countries.Include(t => t.Category)
                        .Include(t => t.Game)
                        .Where(t => ids.Contains(t.CountryID)).ToList();
                session.SetMyCountries(mycountries);
            }

			//get countries - filter by categories and games
			IQueryable<Country> query = context.Countries;
			if (model.ActiveCat != "all")
				query = query.Where(t => t.Category.CategoryId.ToLower() == model.ActiveCat.ToLower());
			if (model.ActiveGame != "all")
				query = query.Where(t => t.Game.GameId.ToLower() == model.ActiveGame.ToLower());

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
		public RedirectToActionResult Add(CountryViewModel model)
		{
			model.Country = context.Countries
				.Include(t => t.Category)
				.Include(t => t.Game)
				.Where(t => t.CountryID == model.Country.CountryID)
				.FirstOrDefault();

			var session = new OlympicSession(HttpContext.Session);
			var countries = session.GetMyCountries();
			countries.Add(model.Country);
			session.SetMyCountries(countries);

			var cookies = new OlympicCookies(HttpContext.Response.Cookies);
			cookies.SetMyCountryIds(countries);

			TempData["message"] = $"{model.Country.Name} added to your favorites";

			return RedirectToAction("Index",
				new
				{
					ActiveConf = session.GetActiveCat(),
					ActiveDiv = session.GetActiveGame()
				});
		}
	}
}
