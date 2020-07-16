using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;

namespace RitoAPI.Services
{
    public class ClashService
    {
        private readonly string _apiKey;

        public ClashService(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }

        public List<ClashPlayerDto> GetActiveClashPlayers(string region, string summonerId = "")
        {
            var url = $"https://{region}.api.riotgames.com//lol/clash/v1/players/by-summoner/{summonerId}?api_key={_apiKey}";

			try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var ClashPlayersJson = streamReader.ReadToEnd();
                        var ClashPlayers = JsonConvert.DeserializeObject<List<ClashPlayerDto>>(ClashPlayersJson);
                        return ClashPlayers;
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