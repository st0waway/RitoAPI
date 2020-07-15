using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("/by-accountId/{id}")]
        public ActionResult<MatchlistDto> GetMatchlistByAccount(string id = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            var summoner = _matchService.GetMatchlistByAccount(id);

            if (summoner == null)
            {
                return BadRequest();
            }

            return Ok(summoner);
        }

        [HttpGet("/by-matchid/{matchid}")]
        public ActionResult<MatchDto> GetMatchById(string matchid = "4688093085")
        {
            var url = "https://euw1.api.riotgames.com/lol/match/v4/matches/" + matchid + "?api_key=";
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