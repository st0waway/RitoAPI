using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
    [Route("league-exp")]
    [ApiController]
    public class LeagueExpController : ControllerBase
    {
        private readonly LeagueExpRepo _repository;
        private readonly string _apiKey;

        public LeagueExpController(IOptions<UserConfig> userConfigAccessor, LeagueExpRepo leagueExpv4)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = leagueExpv4;
        }

        [HttpGet("{queue}/{tier}/{division}")]
        public ActionResult<List<LeagueEntryDTO>> GetLeagueExp(string queue = "RANKED_SOLO_5x5", string tier = "SILVER", string division = "IV")
        {
            var url = "https://euw1.api.riotgames.com/lol/league-exp/v4/entries/" + queue + "/" + tier + "/" + division + "?api_key=" + _apiKey;
            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var LeagueExpJson = sr.ReadToEnd();
                        var LeagueExp = JsonConvert.DeserializeObject<List<LeagueEntryDTO>>(LeagueExpJson);
                        return LeagueExp;
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
