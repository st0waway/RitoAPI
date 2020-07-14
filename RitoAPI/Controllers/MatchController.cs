using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly MatchRepo _repository;
        private readonly string _apiKey;

        public MatchController(IOptions<UserConfig> userConfigAccessor, MatchRepo matchRepo)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = matchRepo;
        }

        [HttpGet("/by-accountId/{id}")]
        public ActionResult<MatchlistDto> GetMatchlistByAccount(string id = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            var url = "https://euw1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + id + "?api_key=" + _apiKey;
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var gameInfoJson = streamReader.ReadToEnd();
                        var gameInfo = JsonConvert.DeserializeObject<MatchlistDto>(gameInfoJson);
                        return gameInfo;
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

        [HttpGet("/by-matchid/{matchid}")]
        public ActionResult<MatchDto> GetMatchById(string matchid = "4688093085")
        {
            var url = "https://euw1.api.riotgames.com/lol/match/v4/matches/" + matchid + "?api_key=" + _apiKey;
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var matchJson = streamReader.ReadToEnd();
                        var match = JsonConvert.DeserializeObject<MatchDto>(matchJson);
                        return match;
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