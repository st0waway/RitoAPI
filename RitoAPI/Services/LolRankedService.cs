using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Services
{
	public class LolRankedService
    {
		private readonly string _apiKey;

		public LolRankedService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public LeaderboardDto GetPlayersInMasterTier(string region)
        {
            var url = $"https://{region}.api.riotgames.com/lor/ranked/v1/leaderboards?api_key={_apiKey}";

            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var playersJson = streamReader.ReadToEnd();
                        var players = JsonConvert.DeserializeObject<LeaderboardDto>(playersJson);
                        return players;
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