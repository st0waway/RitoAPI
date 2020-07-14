using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;

namespace RitoAPI.Services
{
	public class ChampionService
	{
		private readonly string _apiKey;

		public ChampionService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

        public ChampionInfo GetFreeChampionInfo()
        {
            var url = "https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations" + "?api_key=" + _apiKey;

            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var championInfoJson = streamReader.ReadToEnd();
                        var championInfo = JsonConvert.DeserializeObject<ChampionInfo>(championInfoJson);
                        return championInfo;
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
