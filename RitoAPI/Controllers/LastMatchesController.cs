using System;

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

        [HttpPost("one-summoner")]
        public IActionResult GetLastMatchesBySummoner([FromBody]LastMatchSummoner summoner)
        {            
            _logger.LogInformation("GetLastMatchesBySummoner, region = {region}, summonerName = {summonerName}", summoner.region, summoner.summonerName);
            var matches = _lastMatchesService.GetLastMatchesBySummoner(summoner.region, summoner.summonerName);

            if (matches == null)
            {
                return BadRequest();
            }

            return Ok(matches);
        }

        [HttpPost("multiple-summoners")]
        public IActionResult GetMatchesForMultipleSummoners([FromBody]LastMatchSummoners summoners)
        {
            _logger.LogInformation("GetMatchesForMultipleSummoners, region = {region}, summonerNames = {summonerNames} ", summoners.region, String.Join(", ", summoners.summonerNames.ToArray()));
            var multipleSummonerMatches = _lastMatchesService.GetMatchesForMultipleSummoners(summoners.region, summoners.summonerNames);
            
            if (multipleSummonerMatches == null)
            {
                return BadRequest();
            }

            return Ok(multipleSummonerMatches);
        }
    }    
}
