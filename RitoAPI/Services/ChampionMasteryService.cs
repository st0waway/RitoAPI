﻿using System.Collections.Generic;
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
				using (var stream = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(stream))
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

		public ChampionMasteryDTO GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId, long championId)
		{
			var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + encryptedSummonerId + "/by-champion/" + championId + "?api_key=" + _apiKey;
			try
			{
				var webRequest = WebRequest.Create(url) as HttpWebRequest;
				webRequest.ContentType = "application/json";
				webRequest.UserAgent = "Nothing";
				using (var stream = webRequest.GetResponse().GetResponseStream())
				{
					using (var sr = new StreamReader(stream))
					{
						var championMasteryJson = sr.ReadToEnd();
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

		public int GetChampionMasteryScore(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/scores/by-summoner/" + encryptedSummonerId + "?api_key=" + _apiKey;

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
