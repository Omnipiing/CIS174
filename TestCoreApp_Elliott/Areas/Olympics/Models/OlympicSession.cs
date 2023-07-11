using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCoreApp_Elliott.Models.OlympicGames;

namespace TestCoreApp_Elliott.Areas.Olympics.Models
{
    [Area("Olympics")]
    public class OlympicSession
	{
		private const string CountryKey = "mycountries";
		private const string CountKey = "countrycount";
		private const string CatKey = "cat";
		private const string GameKey = "game";

		private ISession session { get; set; }
		public OlympicSession(ISession session)
		{
			this.session = session;
		}

		public void SetMyCountries(List<Country> countries)
		{
			session.SetObject(CountryKey, countries);
			session.SetInt32(CountKey, countries.Count);
		}
		public List<Country> GetMyCountries() =>
			session.GetObject<List<Country>>(CountryKey) ?? new List<Country>();
		public int GetMyCountryCount() => session.GetInt32(CountKey) ?? 0;

		public void SetActiveCat(string activeCat) =>
			session.SetString(CatKey, activeCat);
		public string GetActiveCat() => session.GetString(CatKey);

		public void SetActiveGame(string activeGame) =>
			session.SetString(GameKey, activeGame);
		public string GetActiveGame() => session.GetString(GameKey);

		public void RemoveMyCountries()
		{
			session.Remove(CountryKey);
			session.Remove(CountKey);
		}
	}
}
