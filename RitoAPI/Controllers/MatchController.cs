using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("/by-accountId/{id}/{region}")]
        public IActionResult GetMatchlistByAccountId(string region = "euw1", string id = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
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
            var match = _matchService.GetMatchByMatchId(region, matchid);

            if (match == null)
            {
                return BadRequest();
            }

            return Ok(match);
        }
    }
}