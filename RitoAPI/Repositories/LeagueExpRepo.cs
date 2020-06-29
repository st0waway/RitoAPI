using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Repositories
{
    public class LeagueExpRepo : iLeagueExpRepo
    {
        private readonly string _apiKey;

        public LeagueExpRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
        public List<LeagueEntryDTO> GetLeagueExp(string queue, string tier, string division)
        {
            var url = "https://euw1.api.riotgames.com/lol/league-exp/v4/entries/" + queue + "/" + tier + "/" + division + "?api_key=" + _apiKey;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var LeagueExpJson = sr.ReadToEnd();
                    var LeagueExp = JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(LeagueExpJson);
                    return LeagueExp;
                }
            }
        }
    }
}
