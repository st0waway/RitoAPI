using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("status")]
    [ApiController]
    public class LolStatusController : ControllerBase
    {
        private LolStatusService _lolStatusService;

        public LolStatusController(LolStatusService lolStatusService)
        {
            _lolStatusService = lolStatusService;
        }

        [HttpGet("/{region}")]
        public IActionResult GetLeagueStatus(string region = "EUW1")
        {
            var shardStatus = _lolStatusService.GetLeagueStatus(region);

            if (shardStatus == null)
            {
                return BadRequest();
            }

            return Ok(shardStatus);
        }
    }
}