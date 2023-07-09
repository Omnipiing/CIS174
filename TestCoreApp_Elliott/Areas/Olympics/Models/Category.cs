using Microsoft.AspNetCore.Mvc;

namespace TestCoreApp_Elliott.Models.OlympicGames
{
    [Area("Olympics")]
    public class Category
    {
		public string CategoryId { get; set; }
        public string Name { get; set; }
    }
}
