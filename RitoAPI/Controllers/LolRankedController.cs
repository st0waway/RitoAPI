using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("leaderboards")]
    [ApiController]
    public class LolRankedController : ControllerBase
    {
        private LolRankedService _lolRankedService;
        private readonly ILogger<LolRankedController> _logger;

        public LolRankedController(LolRankedService lolRankedService, ILogger<LolRankedController> logger)
        {
            _lolRankedService = lolRankedService;
            _logger = logger;
        }

        [HttpGet("/by-region/{region}")]
        public IActionResult GetPlayersInMasterTier(string region = "europe")
        {
            _logger.LogInformation("GetPlayersInMasterTier, region = {region}", region);
            var playersInMasterTier = _lolRankedService.GetPlayersInMasterTier(region);

            if (playersInMasterTier == null)
            {
                return BadRequest();
            }

            return Ok(playersInMasterTier);
        }
    }
}