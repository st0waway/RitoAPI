using System;
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
        private readonly ILogger<LastMatchesController> _logger;

        public LastMatchesController(LastMatchesService lastMatchesService, ILogger<LastMatchesController> logger)
        {
            _lastMatchesService = lastMatchesService;
            _logger = logger;
        }

        [HttpPost("one-summoner/{region}")]
        public IActionResult GetLastMatchesBySummoner(string region, [FromBody]string summonerName)
        {            
            _logger.LogInformation("GetLastMatchesBySummoner, region = {region}, summonerName = {summonerName}", region, summonerName);
            var matches = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName);
            return Ok(matches);
        }

        [HttpPost("multiple-summoners/{region}")]
        public IActionResult GetMatchesForMultipleSummoners(string region, [FromBody]List<string> summonerNames)
        {
            var summonerNamesAsString = String.Join(", ", summonerNames.ToArray());
            _logger.LogInformation("GetMatchesForMultipleSummoners, region = {region}, summonerNames = {summonerNames} ", region, summonerNamesAsString);			
            var lobbyMatches = new List<LastMatches>();
			foreach (var summonerName in summonerNames)
			{
                var summonerMatches = _lastMatchesService.GetLastMatchesBySummoner(region, summonerName);
                lobbyMatches.Add(summonerMatches);
            }

            return Ok(lobbyMatches);
        }
    }    
}
