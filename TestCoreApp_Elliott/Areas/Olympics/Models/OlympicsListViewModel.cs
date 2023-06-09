﻿using Microsoft.AspNetCore.Mvc;
using TestCoreApp_Elliott.Areas.Olympics.Models;

namespace TestCoreApp_Elliott.Models.OlympicGames
{
	[Area("Olympics")]
	public class OlympicsListViewModel : CountryViewModel
	{
		public List<Country> Countries { get; set; }


        private List<Category> categories;
		public List<Category> Categories
		{
			get => categories;
			set
			{
				categories = new List<Category>
				{
					new Category { CategoryId = "all", Name = "All" }
				};
				categories.AddRange(value);
			}
		}

		private List<Game> games;
		public List<Game> Games
		{
			get => games;
			set
			{
				games = new List<Game>
				{
					new Game { GameId = "all", Name = "All" }
				};
				games.AddRange(value);
			}
		}

		//methods to help view determine active link
		public string CheckActiveCat(string c) =>
			c.ToLower() == ActiveCat.ToLower() ? "active" : "";

		public string CheckActiveGame(string g) =>
			g.ToLower() == ActiveGame.ToLower() ? "active" : "";
	}
}
