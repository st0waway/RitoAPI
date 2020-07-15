using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;

namespace RitoAPI.Services
{
	public class MatchService
	{
		private readonly string _apiKey;

		public MatchService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public MatchlistDto GetMatchlistByAccountId(string id)
		{
			var url = "https://euw1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + id + "?api_key=" + _apiKey;

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
						var gameInfo = JsonConvert.DeserializeObject<MatchlistDto>(gameInfoJson);
						return gameInfo;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public MatchDto GetMatchByMatchId(string matchid)
		{
			var url = "https://euw1.api.riotgames.com/lol/match/v4/matches/" + matchid + "?api_key=" + _apiKey;

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";
				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var matchJson = streamReader.ReadToEnd();
						var match = JsonConvert.DeserializeObject<MatchDto>(matchJson);
						return match;
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
