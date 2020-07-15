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

        [HttpGet]
        public IActionResult GetLeagueStatus(string server = "EUW1")
        {
            var shardStatus = _lolStatusService.GetLeagueStatus(server);

            if (shardStatus == null)
            {
                return BadRequest();
            }

            return Ok(shardStatus);
        }
    }
}