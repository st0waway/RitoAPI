using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
    [ApiController]
    public class ChampionController : ControllerBase
    {
        private readonly ChampionRepo _repository;
        private readonly string _apiKey;

        public ChampionController(IOptions<UserConfig> userConfigAccessor, ChampionRepo championRepo)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = championRepo;
        }

        [HttpGet("champion-rotations")]
        public ActionResult<ChampionInfo> GetChampionInfo()
        {
            var url = "https://euw1.api.riotgames.com/lol/platform/v3/champion-rotations" + "?api_key=" + _apiKey;
            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var championInfoJson = sr.ReadToEnd();
                        var championInfo = JsonConvert.DeserializeObject<ChampionInfo>(championInfoJson);
                        return championInfo;
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