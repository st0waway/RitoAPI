﻿using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("clash")]
    [ApiController]
    public class ClashController : ControllerBase
    {
        private readonly ClashRepo _repository;
        private readonly string _apiKey;

        public ClashController(IOptions<UserConfig> userConfigAccessor, ClashRepo clashv1Repo)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = clashv1Repo;
        }       

        [HttpGet("bySummoner/{summonerId}")]
        public ActionResult<List<ClashPlayerDto>> GetActiveClashPlayers(string summonerId = "")
        {
            var url = "https://euw1.api.riotgames.com//lol/clash/v1/players/by-summoner/" + summonerId + "?api_key=" + _apiKey;
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.UserAgent = "Nothing";
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var ClashPlayersJson = streamReader.ReadToEnd();
                        var ClashPlayers = JsonConvert.DeserializeObject<List<ClashPlayerDto>>(ClashPlayersJson);
                        return ClashPlayers;
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
