using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private MatchService _matchService;
        private readonly ILogger<MatchController> _logger;

        public MatchController(MatchService matchService, ILogger<MatchController> logger)
        {
            _matchService = matchService;
            _logger = logger;
        }

        [HttpGet("/by-accountId/{id}/{region}")]
        public IActionResult GetMatchlistByAccountId(string region = "euw1", string id = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            _logger.LogInformation("GetMatchlistByAccountId, region = {region}, id = {id}", region, id);
            var matchList = _matchService.GetMatchlistByAccountId(region, id);

            if (matchList == null)
            {
                return BadRequest();
            }

            return Ok(matchList);
        }

        [HttpGet("/by-matchid/{matchid}/{region}")]
        public IActionResult GetMatchByMatchId(string region= "euw1", string matchid = "4688093085")
        {
            _logger.LogInformation("GetMatchByMatchId, region = {region}, matchid = {matchid}", region, matchid);
            var match = _matchService.GetMatchByMatchId(region, matchid);

            if (match == null)
            {
                return BadRequest();
            }

            return Ok(match);
        }
    }
}