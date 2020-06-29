using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class SpectatorRepo
    {
        private readonly string _apiKey;

        public SpectatorRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }

        public FeaturedGames GetFeaturedGames()
        {
            var url = "https://euw1.api.riotgames.com/lol/spectator/v4/featured-games" + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var featuredGameInfoJson = sr.ReadToEnd();
                    var featuredGameInfo = JsonConvert.DeserializeObject<FeaturedGames>(featuredGameInfoJson);
                    return featuredGameInfo;
                }
            }
        }
    }
}
