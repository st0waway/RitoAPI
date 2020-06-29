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

        [HttpGet("name/{name}")]
        public ActionResult<SummonerDTO> GetSummonerByName(string name = "Lum1x")
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + name + "?api_key=" + _apiKey;
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

        [HttpGet("accountId/{accountId}")]
        public ActionResult<SummonerDTO> GetSummonerByAccount(string accountId = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-account/" + accountId + "?api_key=" + _apiKey;
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
                        return summoner;
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

        [HttpGet("puuid/{puuid}")]
        public ActionResult<SummonerDTO> GetSummonerByPUUID(string puuid = "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA")
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/" + puuid + "?api_key=" + _apiKey;
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
                        return summoner;
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

        [HttpGet("id/{id}")]
        public ActionResult<SummonerDTO> GetSummonerBySummonerID(string id = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
        {
            var url = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/" + id + "?api_key=" + _apiKey;
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
                        return summoner;
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