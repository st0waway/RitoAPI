using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

            if (matches == null)
            {
                return BadRequest();
            }

            return Ok(matches);
        }

        [HttpPost("multiple-summoners/{region}")]
        public IActionResult GetMatchesForMultipleSummoners(string region, [FromBody]List<string> summonerNames)
        {
            _logger.LogInformation("GetMatchesForMultipleSummoners, region = {region}, summonerNames = {summonerNames} ", region, String.Join(", ", summonerNames.ToArray()));
            var multipleSummonerMatches = _lastMatchesService.GetMatchesForMultipleSummoners(region, summonerNames);
            
            if (multipleSummonerMatches == null)
            {
                return BadRequest();
            }

            return Ok(multipleSummonerMatches);
        }
    }    
}
