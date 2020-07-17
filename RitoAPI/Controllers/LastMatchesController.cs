using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("last-matches")]
    [ApiController]
    public class LastMatchesController : ControllerBase
	{
        private LastMatchesService _lastMatchesService;

        public LastMatchesController(LastMatchesService lastMatchesService)
        {
            _lastMatchesService = lastMatchesService;
        }
        [HttpGet("{summonerName}")]
        public IActionResult GetLastMatchesBySummoner(string region = "euw1", string summonerName = "Lum1x")
        {
            var matches = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName);
            return Ok(matches);
        }

        [HttpGet("{summonerName1}/{summonerName2}/{summonerName3}/{summonerName4}/{summonerName5}")]
        public IActionResult GetLastMatchesForLobby(string region = "euw1", string summonerName1 = "Lum1x", string summonerName2 = "Lum1x", string summonerName3 = "Lum1x", string summonerName4 = "Lum1x", string summonerName5 = "Lum1x")
        {
            var lobbyInfo = new LobbyInfo();
            var lobbyMatches = new List<LastMatches>();
            var matchesSummoner1 = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName1);
            var matchesSummoner2 = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName2);
            var matchesSummoner3 = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName3);
            var matchesSummoner4 = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName4);
            var matchesSummoner5 = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName5);
            lobbyMatches.Add(matchesSummoner1);
            lobbyMatches.Add(matchesSummoner2);
            lobbyMatches.Add(matchesSummoner3);
            lobbyMatches.Add(matchesSummoner4);
            lobbyMatches.Add(matchesSummoner5);
            return Ok(lobbyMatches);
        }
    }
}
