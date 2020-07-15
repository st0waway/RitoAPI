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

        [HttpGet("/by-accountId/{id}")]
        public IActionResult GetMatchlistByAccountId(string id = "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI")
        {
            var summoner = _matchService.GetMatchlistByAccountId(id);

            if (summoner == null)
            {
                return BadRequest();
            }

            return Ok(summoner);
        }

        [HttpGet("/by-matchid/{matchid}")]
        public IActionResult GetMatchByMatchId(string matchid = "4688093085")
        {
            var summoner = _matchService.GetMatchByMatchId(matchid);

            if (summoner == null)
            {
                return BadRequest();
            }

            return Ok(summoner);
        }
    }
}