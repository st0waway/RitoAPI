using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class Spectatorv4Repo
    {
        string apikey = "RGAPI-6bc0db09-5158-4b23-b364-7ec924315239";
        public CurrentGameInfo GetGameInfo(string encryptedSummonerId)
        {
            var url = "https://euw1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/" + encryptedSummonerId + "?api_key=" + apikey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var gameInfoJson = sr.ReadToEnd();
                    var gameInfo = JsonConvert.DeserializeObject<CurrentGameInfo>(gameInfoJson);
                    return gameInfo;
                }
            }
        }
    }
}
