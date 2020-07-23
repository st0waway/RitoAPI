using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("league-exp")]
    [ApiController]
    public class LeagueExpController : ControllerBase
    {
        private LeagueExpService _leagueExpService;
        private readonly ILogger<LeagueExpController> _logger;

        public LeagueExpController(LeagueExpService leagueExpService, ILogger<LeagueExpController> logger)
        {
            _leagueExpService = leagueExpService;
            _logger = logger;
        }

        [HttpGet("{queue}/{tier}/{division}/{region}")]
        public IActionResult GetLeagueExp(string region = "euw1", string queue = "RANKED_SOLO_5x5", string tier = "GOLD", string division = "IV")
        {
            var leagueInfo = _leagueExpService.GetLeagueExp(region , queue, tier, division);

            if (leagueInfo == null)
            {
                return BadRequest();
            }

            return Ok(leagueInfo);
        }
    }
}
