using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
    [Route("summoner")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly string _apiKey;

        public SummonerController(IOptions<UserConfig> userConfigAccessor, SummonerRepo summonerv4Repo)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = summonerv4Repo;
        }

        private readonly SummonerRepo _repository;

        [HttpGet("by-name/{summonerName}")]
        public ActionResult<SummonerDTO> GetSummonerByName(string summonerName = "Lum1x")
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + summonerName + "?api_key=" + _apiKey;

            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var summonerAsJson = sr.ReadToEnd();
                        var summoner = JsonConvert.DeserializeObject<SummonerDTO>(summonerAsJson);
                        return Ok(summoner);
                    }
                }
            }
            catch (WebException e)
            {
                return NotFound(e.Message);
            }  
        }

        [HttpGet("by-account/{encryptedAccountId}")]
        public ActionResult<SummonerDTO> GetSummonerByAccount(string encryptedAccountId = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            var summoner = _repository.GetSummonerByAccount(encryptedAccountId);
            if (summoner.Name != null)
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("by-puuid/{encryptedPUUID}")]
        public ActionResult<SummonerDTO> GetSummonerByPUUID(string encryptedPUUID = "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA")
        {
            var summoner = _repository.GetSummonerByPUUID(encryptedPUUID);
            if (summoner.Name != null)
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{encryptedSummonerId}")]
        public ActionResult<SummonerDTO> GetSummonerBySummonerID(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
        {
            var summoner = _repository.GetSummonerBySummonerID(encryptedSummonerId);
            if (summoner.Name != null)
            {
                return Ok(summoner);
            }
            else
            {
                return NotFound();
            }
        }
    }
}