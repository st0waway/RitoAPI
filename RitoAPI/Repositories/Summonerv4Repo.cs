using RitoAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace RitoAPI.Repositories
{
    public class Summonerv4Repo : iSummonerv4Repo
    {
        string apikey = "RGAPI-6bc0db09-5158-4b23-b364-7ec924315239";
        public SummonerDTO GetSummonerByName(string userid)
        {            
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + userid + "?api_key=" + apikey;
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

        public SummonerDTO GetSummonerByAccount(string encryptedAccountId)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-account/" + encryptedAccountId + "?api_key=" + apikey;
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

        public SummonerDTO GetSummonerByPUUID(string encryptedPUUID)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/" + encryptedPUUID + "?api_key=" + apikey;
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

        public SummonerDTO GetSummonerBySummonerID(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/" + encryptedSummonerId + "?api_key=" + apikey;
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
    }
}
