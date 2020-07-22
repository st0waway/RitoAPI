using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("status")]
    [ApiController]
    public class LolStatusController : ControllerBase
    {
        private LolStatusService _lolStatusService;
        private readonly ILogger<LolStatusController> _logger;

        public LolStatusController(LolStatusService lolStatusService, ILogger<LolStatusController> logger)
        {
            _lolStatusService = lolStatusService;
            _logger = logger;
        }

        [HttpGet("{region}")]
        public IActionResult GetLeagueStatus(string region = "EUW1")
        {
            _logger.LogInformation("GetLeagueStatus, region = {region}", region);
            var shardStatus = _lolStatusService.GetLeagueStatus(region);

            if (shardStatus == null)
            {
                return BadRequest();
            }

            return Ok(shardStatus);
        }
    }
}