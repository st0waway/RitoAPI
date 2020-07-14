using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Services;
using System.Collections.Generic;

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
            var championMasteries = _leagueExpService.GetLeagueExp(queue, tier, division);

            if (championMasteries == null)
            {
                return BadRequest();
            }

            return Ok(championMasteries);
        }
    }
}
