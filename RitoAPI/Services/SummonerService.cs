using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Services
{
	public class SummonerService
	{
		private readonly string _apiKey;

		public SummonerService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public SummonerDTO GetSummonerByName(string name)
		{
			var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + name + "?api_key=" + _apiKey;

			try
			{
				var webRequest = WebRequest.Create(url) as HttpWebRequest;
				webRequest.ContentType = "application/json";
				webRequest.UserAgent = "Nothing";

				using (var s = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(s))
					{
						var summonerAsJson = sr.ReadToEnd();
						var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
						return summoner;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public SummonerDTO GetSummonerByAccount(string accountId)
		{
			var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-account/" + accountId + "?api_key=" + _apiKey;
			try
			{
				var webRequest = WebRequest.Create(url) as HttpWebRequest;
				webRequest.ContentType = "application/json";
				webRequest.UserAgent = "Nothing";

				using (var s = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(s))
					{
						var summonerAsJson = sr.ReadToEnd();
						var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
						return summoner;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public SummonerDTO GetSummonerByPUUID(string puuid)
		{
			var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/" + puuid + "?api_key=" + _apiKey;
			try
			{
				var webRequest = WebRequest.Create(url) as HttpWebRequest;
				webRequest.ContentType = "application/json";
				webRequest.UserAgent = "Nothing";

				using (var s = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(s))
					{
						var summonerAsJson = sr.ReadToEnd();
						var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
						return summoner;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public SummonerDTO GetSummonerBySummonerID(string id)
		{
			var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/" + id + "?api_key=" + _apiKey;
			try
			{
				var webRequest = WebRequest.Create(url) as HttpWebRequest;
				webRequest.ContentType = "application/json";
				webRequest.UserAgent = "Nothing";

				using (var s = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(s))
					{
						var summonerAsJson = sr.ReadToEnd();
						var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
						return summoner;
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
