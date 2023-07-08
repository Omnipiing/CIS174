using Microsoft.AspNetCore.Mvc;

namespace TestCoreApp_Elliott.Models.OlympicGames
{
    [Area("Olympics")]
    public class Game
    {
        public string GameId { get; set; }
        public string Name { get; set; }
    }
}
