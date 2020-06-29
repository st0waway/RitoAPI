using RitoAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace RitoAPI.Repositories
{
    public class SummonerRepo : iSummonerRepo
    {
        private readonly string _apiKey;        

        public SummonerRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        } 

        public SummonerDTO GetSummonerBySummonerID(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/" + encryptedSummonerId + "?api_key=" + _apiKey;
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
