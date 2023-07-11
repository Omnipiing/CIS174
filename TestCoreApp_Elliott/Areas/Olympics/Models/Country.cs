using Microsoft.AspNetCore.Mvc;

namespace TestCoreApp_Elliott.Models.OlympicGames
{
	[Area("Olympics")]
	public class Country
    {
        public string CountryID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Game Game { get; set; }
        public string FlagImage { get; set; }
    }
}
