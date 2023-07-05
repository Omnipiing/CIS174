using Microsoft.AspNetCore.Mvc;
using TestCoreApp_Elliott.Models.OlympicGames;

namespace TestCoreApp_Elliott.Controllers.OlympicGames
{
	public class CountryController : Controller
	{
		private CountryContext context;

		public CountryController(CountryContext ctx)
		{
			context = ctx;
		}

		public ViewResult Index(string activeCat = "all", string activeGame = "all")
		{
			var model = new CountryListViewModel
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
	}
}
