using TestCoreApp_Elliott.Models.OlympicGames;

namespace TestCoreApp_Elliott.Areas.Olympics.Models
{
	public class CountryViewModel
	{
		public Country Country { get; set; }
		public string ActiveCat { get; set; }
		public string ActiveGame { get; set; }
	}
}
