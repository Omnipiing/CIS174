using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestCoreApp_Elliott.Areas.Olympics.Models
{
    [Area("Olympics")]
    public static class SessionExtensions
	{
		public static void SetObject<T>(this ISession session,
			string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T GetObject<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return (string.IsNullOrEmpty(value)) ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}
}
