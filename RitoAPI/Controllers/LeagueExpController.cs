﻿using Microsoft.AspNetCore.Mvc;
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

        public LeagueExpController(IOptions<UserConfig> userConfigAccessor, LeagueExpRepo leagueExp)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = leagueExp;
        }

        [HttpGet("{queue}/{tier}/{division}")]
        public ActionResult<List<LeagueEntryDTO>> GetLeagueExp(string queue = "RANKED_SOLO_5x5", string tier = "SILVER", string division = "IV")
        {
            var url = "https://euw1.api.riotgames.com/lol/league-exp/v4/entries/" + queue + "/" + tier + "/" + division + "?api_key=" + _apiKey;
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var LeagueExpJson = streamReader.ReadToEnd();
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
