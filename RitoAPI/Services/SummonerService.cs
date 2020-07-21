using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;
using Microsoft.Extensions.Logging;

namespace RitoAPI.Services
{
	public class SummonerService
	{
		private readonly string _apiKey;
		private readonly ILogger<SummonerService> _logger;

		public SummonerService(IOptions<UserConfig> userConfigAccessor, ILogger<SummonerService> logger)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
			_logger = logger;
		}

		public SummonerDTO GetSummonerByName(string region, string name)
		{
			var url = $"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var summonerAsJson = streamReader.ReadToEnd();
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

		public SummonerDTO GetSummonerByAccount(string region, string accountId)
		{
			var url = $"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-account/{accountId}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;

				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var summonerAsJson = streamReader.ReadToEnd();
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

		public SummonerDTO GetSummonerByPUUID(string region, string puuid)
		{
			var url = $"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{puuid}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";

				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var summonerAsJson = streamReader.ReadToEnd();
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

		public SummonerDTO GetSummonerBySummonerID(string region, string id)
		{
			var url = $"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/{id}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";

				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var summonerAsJson = streamReader.ReadToEnd();
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
