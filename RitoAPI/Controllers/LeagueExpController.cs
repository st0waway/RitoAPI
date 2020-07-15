using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("league-exp")]
    [ApiController]
    public class LeagueExpController : ControllerBase
    {
        private LeagueExpService _leagueExpService;

        public LeagueExpController(LeagueExpService leagueExpService)
        {
            _leagueExpService = leagueExpService;
        }

        [HttpGet("{queue}/{tier}/{division}")]
        public IActionResult GetLeagueExp(string queue = "RANKED_SOLO_5x5", string tier = "GOLD", string division = "IV")
        {
            var leagueInfo = _leagueExpService.GetLeagueExp(queue, tier, division);

            if (leagueInfo == null)
            {
                return BadRequest();
            }

            return Ok(leagueInfo);
        }
    }
}
