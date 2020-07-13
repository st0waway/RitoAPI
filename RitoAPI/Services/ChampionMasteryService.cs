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

		public List<ChampionMasteryDTO> GetChamcpionMasteryBySummoner(string encryptedSummonerId)
		{

			var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + encryptedSummonerId + "?api_key=" + _apiKey;
			try
			{
				var webRequest = WebRequest.Create(url) as HttpWebRequest;
				webRequest.ContentType = "application/json";
				webRequest.UserAgent = "Nothing";
				using (var s = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(s))
					{
						var championMasteryListJson = sr.ReadToEnd();
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
	}
}