using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
    [Route("leaderboards")]
    [ApiController]
    public class LolRankedController : ControllerBase
    {
        private readonly LolRankedRepo _repository;
        private readonly string _apiKey;

        public LolRankedController(IOptions<UserConfig> userConfigAccessor, LolRankedRepo lolRankedv1Repo)
        {
            _apiKey = userConfigAccessor.Value.APIKey; 
            _repository = lolRankedv1Repo;
        }
        
        [HttpGet]
        public ActionResult<LeaderboardDto> GetPlayersInMasterTier(string region = "europe")
        {
            var url = "https://" + region + ".api.riotgames.com/lor/ranked/v1/leaderboards" + "?api_key=" + _apiKey;
            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var playersJson = sr.ReadToEnd();
                        var players = JsonConvert.DeserializeObject<LeaderboardDto>(playersJson);
                        return players;
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