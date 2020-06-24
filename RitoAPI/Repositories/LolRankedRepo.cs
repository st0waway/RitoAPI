using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class LolRankedRepo
    {
        private readonly string _apiKey;

        public LolRankedRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
        public LeaderboardDto GetPlayersInMasterTier(string region)
        {
            var url = "https://" + region + ".api.riotgames.com/lor/ranked/v1/leaderboards" + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var playersJson = sr.ReadToEnd();
                    var players = JsonConvert.DeserializeObject<LeaderboardDto>(playersJson);
                    return players;
                }
            }
        }
    }
}
