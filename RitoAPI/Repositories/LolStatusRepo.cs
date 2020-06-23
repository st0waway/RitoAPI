using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class LolStatusRepo
    {
        private readonly string _apiKey;

        public LolStatusRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
        public ShardStatus GetLeagueStatus(string region)
        {
            var url = "https://" + region + ".api.riotgames.com/lol/status/v3/shard-data" + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var shardStatusJson = sr.ReadToEnd();
                    var shardStatus = JsonConvert.DeserializeObject<ShardStatus>(shardStatusJson);
                    return shardStatus;
                }
            }
        }
    }
}
