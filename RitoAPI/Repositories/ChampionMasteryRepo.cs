using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class ChampionMasteryRepo : iChampionMasteryRepo
    {
        private readonly string _apiKey;

        public ChampionMasteryRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }        
        public List<ChampionMasteryDTO> GetChampionMasteryBySummoner(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + encryptedSummonerId + "?api_key=" + _apiKey;
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

        public ChampionMasteryDTO GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId, long championId)
        {
            var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + encryptedSummonerId + "/by-champion/" + championId +"?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var championMasteryJson = sr.ReadToEnd();
                    var championMastery = JsonConvert.DeserializeObject<ChampionMasteryDTO>(championMasteryJson);
                    return championMastery;
                }
            }
        }
    }
}
