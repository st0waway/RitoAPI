using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Models;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("clash")]
    [ApiController]
    public class ClashController : ControllerBase
    {
        private ClashService _clashService;
        private readonly ILogger<SummonerController> _logger;

        public ClashController(ClashService clashService, ILogger<SummonerController> logger)
        {
            _clashService = clashService;
            _logger = logger;
        }

        [HttpGet("bySummoner/{summonerId}/{region}")]
        public ActionResult<List<ClashPlayerDto>> GetActiveClashPlayers(string region = "euw", string summonerId = "Lum1x")
        {
            _logger.LogInformation("GetActiveClashPlayers, region = {region}, summonerId = {summonerId}", region, summonerId);
            var clashPlayers = _clashService.GetActiveClashPlayers(region, summonerId);

            if (clashPlayers == null)
            {
                return BadRequest();
            }

            return Ok(clashPlayers);
        }
    }
}
