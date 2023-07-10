using Microsoft.AspNetCore.Mvc;
using TestCoreApp_Elliott.Models.OlympicGames;

namespace TestCoreApp_Elliott.Areas.Olympics.Models
{
    [Area("Olympics")]
    public class CountryViewModel
	{
		public Country Country { get; set; }
		public string ActiveCat { get; set; }
		public string ActiveGame { get; set; }
	}
}
