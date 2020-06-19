using Newtonsoft.Json;
using RitoAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class ChampionMasteryv4Repo : iChampionMasteryv4Repo
    {
        string apikey = "RGAPI-6bc0db09-5158-4b23-b364-7ec924315239";
        public List<ChampionMasteryDTO> GetChampionMasteryBySummoner(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + encryptedSummonerId + "?api_key=" + apikey;
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
            var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + encryptedSummonerId + "/by-champion/" + "?api_key=" + championId + apikey;
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

        public int GetChampionMasteryScore(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/scores/by-summoner/" + encryptedSummonerId + "?api_key=" + apikey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var championMasteryJson = sr.ReadToEnd();
                    var championMastery = JsonConvert.DeserializeObject<int>(championMasteryJson);
                    return championMastery;
                }
            }
        }        
    }
}
