using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;

namespace RitoAPI.Services
{
	public class ChampionMasteryService
	{
		private readonly string _apiKey;

		public ChampionMasteryService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public List<ChampionMasteryDTO> GetChampionsMasteryById(string region, string id)
		{

			var url = $"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{id}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";
				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var championMasteryListJson = streamReader.ReadToEnd();
						var championMasteryList = JsonConvert.DeserializeObject<List<ChampionMasteryDTO>>(championMasteryListJson);
						return championMasteryList;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public ChampionMasteryDTO GetChampionMasteryByIdandChampionId(string region, string encryptedSummonerId, long championId)
		{
			var url = $"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/by-champion/{championId}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;
				request.ContentType = "application/json";
				request.UserAgent = "Nothing";
				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var championMasteryJson = streamReader.ReadToEnd();
						var championMastery = JsonConvert.DeserializeObject<ChampionMasteryDTO>(championMasteryJson);
						return championMastery;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public int GetChampionMasteryScore(string region ,string encryptedSummonerId)
		{
			var url = $"https://{region}.api.riotgames.com/lol/champion-mastery/v4/scores/by-summoner/{encryptedSummonerId}?api_key={_apiKey}";

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;

				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var championMasteryJson = streamReader.ReadToEnd();
						var championMastery = JsonConvert.DeserializeObject<int>(championMasteryJson);
						return championMastery;
					}
				}
			}
			catch (WebException ex)
			{
				var response = ex.Response as HttpWebResponse;
				throw new InvalidDataException($"The request to riotgames.com has returned with status code " + (int) response.StatusCode);
			}
		}
	}
}
