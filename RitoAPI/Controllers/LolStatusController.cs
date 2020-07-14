using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
    [Route("status")]
    [ApiController]
    public class LolStatusController : ControllerBase
    {
        private readonly LolStatusRepo _repository;
        private readonly string _apiKey;

        public LolStatusController(IOptions<UserConfig> userConfigAccessor, LolStatusRepo lolStatusRepo)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = lolStatusRepo;
        }

        [HttpGet]
        public ActionResult<ShardStatus> GetLeagueStatus(string server = "EUW1")
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
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = e.Response as HttpWebResponse;
                    if (response != null)
                    {
                        var code = (int)response.StatusCode;
                        return StatusCode(code);
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }
    }
}