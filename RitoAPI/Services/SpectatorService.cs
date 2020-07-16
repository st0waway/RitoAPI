using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Services
{
	public class SpectatorService
	{
		private readonly string _apiKey;

		public SpectatorService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public CurrentGameInfo GetGameInfo(string region, string id)
		{
			var url = $"https://{region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{id}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";
				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var gameInfoJson = streamReader.ReadToEnd();
						var gameInfo = JsonConvert.DeserializeObject<CurrentGameInfo>(gameInfoJson);
						return gameInfo;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public FeaturedGames GetFeaturedGames(string region)
		{
			var url = $"https://{region}.api.riotgames.com/lol/spectator/v4/featured-games?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";
				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var featuredGameInfoJson = streamReader.ReadToEnd();
						var featuredGameInfo = JsonConvert.DeserializeObject<FeaturedGames>(featuredGameInfoJson);
						return featuredGameInfo;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}
	}
}