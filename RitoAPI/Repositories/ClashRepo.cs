using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class ClashRepo
    {
        private readonly string _apiKey;

        public ClashRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
        public List<ClashPlayerDto> GetActiveClashPlayers(string summonerId)
        {
            var url = "https://euw1.api.riotgames.com//lol/clash/v1/players/by-summoner/" + summonerId + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var ClashPlayersJson = sr.ReadToEnd();
                    var ClashPlayers = JsonConvert.DeserializeObject<List<ClashPlayerDto>>(ClashPlayersJson);
                    return ClashPlayers;
                }
            }
        }
    }
}
