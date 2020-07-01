using System.Collections.Generic;
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
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var gameInfoJson = sr.ReadToEnd();
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
    }
}