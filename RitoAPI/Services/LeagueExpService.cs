using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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

        public List<LeagueEntryDTO> GetLeagueExp(string region, string queue, string tier, string division)
        {
            var url = $"https://{region}.api.riotgames.com/lol/league-exp/v4/entries/{queue}/{tier}/{division}?api_key={_apiKey}";

            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                if (request == null) throw new HttpRequestException("The response was null.");
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using var stream = request.GetResponse().GetResponseStream();
                if (stream == null) throw new HttpRequestException("The response stream was null.");
                using var streamReader = new StreamReader(stream);
                var leagueExpJson = streamReader.ReadToEnd();
                var leagueExp = JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(leagueExpJson);
                return leagueExp;

            }
            catch (WebException)
            {
                return null;
            }
        }
    }
}
