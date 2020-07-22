using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Models;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("last-matches")]
    [ApiController]
    public class LastMatchesController : ControllerBase
	{
        private LastMatchesService _lastMatchesService;
        private readonly ILogger<SummonerController> _logger;

        public LastMatchesController(LastMatchesService lastMatchesService, ILogger<SummonerController> logger)
        {
            _lastMatchesService = lastMatchesService;
            _logger = logger;
        }

        [HttpGet("{summonerName}")]
        public IActionResult GetLastMatchesBySummoner(string region = "euw1", string summonerName = "Lum1x")
        {
            _logger.LogInformation("GetActiveClashPlayers, region = {region}, summonerName = {summonerName}", region, summonerName);
            var matches = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName);
            return Ok(matches);
        }

        [HttpGet("{summonerName1}/{summonerName2}/{summonerName3}/{summonerName4}/{summonerName5}")]
        public IActionResult GetLastMatchesForLobby(string region = "euw1", string summonerName1 = "Lum1x", string summonerName2 = "Lum1x", string summonerName3 = "Lum1x", string summonerName4 = "Lum1x", string summonerName5 = "Lum1x")
        {
            _logger.LogInformation("GetActiveClashPlayers, region = {region}, summonerName1 = {summonerName1}, summonerName2 = {summonerName2}, summonerName3 = {summonerName3}, summonerName4 = {summonerName4}, summonerName5 = {summonerName5}, ", region, summonerName1, summonerName2, summonerName3, summonerName4, summonerName5);
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
