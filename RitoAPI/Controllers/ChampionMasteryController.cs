using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using RitoAPI.Services;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
    [Route("champion-masteries")]
    [ApiController]
    public class ChampionMasteryController : ControllerBase
    {
        private ChampionMasteryService _championMasteryService;

        public ChampionMasteryController(ChampionMasteryService championMasteryService)
        {
            _championMasteryService = championMasteryService;
        }

        [HttpGet("by-summoner/{encryptedSummonerId}")]
        public IActionResult GetChamcpionMasteryBySummoner(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
        {
            var championMasteries = _championMasteryService.GetChamcpionMasteryBySummoner(encryptedSummonerId);

            if (championMasteries == null)
            {
                return BadRequest();
            }

            return Ok(championMasteries);
        }

        [HttpGet("by-summoner/{encryptedSummonerId}/by-champion/{championId}")]
        public IActionResult GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", long championId = 1)
        {
            var championMasteries = _championMasteryService.GetChampionMasteryByPlayerIDandChampionID(encryptedSummonerId, championId);

            if (championMasteries == null)
            {
                return BadRequest();
            }

            return Ok(championMasteries);
        }

        [HttpGet("scores/{encryptedSummonerId}")]
        public IActionResult GetChampionMasteryScore(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
        {

            var url = "https://euw1.api.riotgames.com/lol/champion-mastery/v4/scores/by-summoner/" + encryptedSummonerId + "?api_key=";
            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var championMasteryJson = sr.ReadToEnd();
                        var championMastery = JsonConvert.DeserializeObject<int>(championMasteryJson);
                        return Ok(championMastery);
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