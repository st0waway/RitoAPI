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
    public class SpectatorController : ControllerBase
    {
        private readonly SpectatorRepo _repository;
        private readonly string _apiKey;

        public SpectatorController(IOptions<UserConfig> userConfigAccessor, SpectatorRepo spectatorv4Repo)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
            _repository = spectatorv4Repo;
        }

        [HttpGet("spectate/{id}")]
        public ActionResult<CurrentGameInfo> GetGameInfo(string id = "fYjvBkqrZjvJ54r6tpH0wY2-CoNQFc5lIW92E-nFnUClTPE")
        {
            var url = "https://euw1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/" + id + "?api_key=" + _apiKey;
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
                        var gameInfo = JsonConvert.DeserializeObject<CurrentGameInfo>(gameInfoJson);
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
        [HttpGet("featured-games")]
        public ActionResult<FeaturedGames> GetFeaturedGames()
        {
            var url = "https://euw1.api.riotgames.com/lol/spectator/v4/featured-games" + "?api_key=" + _apiKey;
            try
            {
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var featuredGameInfoJson = sr.ReadToEnd();
                        var featuredGameInfo = JsonConvert.DeserializeObject<FeaturedGames>(featuredGameInfoJson);
                        return featuredGameInfo;
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