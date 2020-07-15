using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Services
{
	public class LolStatusService
	{
		private readonly string _apiKey;

		public LolStatusService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public ShardStatus GetLeagueStatus(string server)
        {
            var url = "https://" + server + ".api.riotgames.com/lol/status/v3/shard-data" + "?api_key=" + _apiKey;
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var shardStatusJson = streamReader.ReadToEnd();
                        var shardStatus = JsonConvert.DeserializeObject<ShardStatus>(shardStatusJson);
                        return shardStatus;
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