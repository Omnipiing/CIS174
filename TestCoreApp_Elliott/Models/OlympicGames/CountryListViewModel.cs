namespace TestCoreApp_Elliott.Models.OlympicGames
{
	public class CountryListViewModel
	{
		public List<Country> Countries { get; set; }
		public string ActiveCat { get; set; }
		public string ActiveGame { get; set; }

		private List<Category> categories;
		public List<Category> Categories
		{
			get => categories;
			set
			{
				categories = value;
				categories.Insert(0, new Category { CategoryId = "all", Name = "All" });
			}
		}

		private List<Game> games;
		public List<Game> Games
		{
			get => games;
			set
			{
				games = value;
				games.Insert(0, new Game { GameId = "all", Name = "All" });
			}
		}

		//methods to help view determine active link
		public string CheckActiveCat(string c) =>
			c.ToLower() == ActiveCat.ToLower() ? "active" : "";

		public string CheckActiveGame(string g) =>
			g.ToLower() == ActiveGame.ToLower() ? "active" : "";
	}
}
