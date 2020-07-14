using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;

namespace RitoAPI.Services
{
    public class LeagueExpService
    {
        private readonly string _apiKey;

        public LeagueExpService(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }

        public List<LeagueEntryDTO> GetLeagueExp(string queue, string tier, string division)
        {
            var url = "https://euw1.api.riotgames.com/lol/league-exp/v4/entries/" + queue + "/" + tier + "/" + division + "?api_key=" + _apiKey;

            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var LeagueExpJson = streamReader.ReadToEnd();
                        var LeagueExp = JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(LeagueExpJson);
                        return LeagueExp;
                    }
                }
            }
            catch (WebException)
            {
                return null;
            }
        }
    }
}
