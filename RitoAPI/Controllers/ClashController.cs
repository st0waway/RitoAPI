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
        private readonly ILogger<ClashController> _logger;

        public ClashController(ClashService clashService, ILogger<ClashController> logger)
        {
            _clashService = clashService;
            _logger = logger;
        }

        [HttpGet("bySummoner/{summonerId}/{region}")]
        public ActionResult<List<ClashPlayerDto>> GetActiveClashPlayers(string region = "euw", string summonerId = "Lum1x")
        {
            var clashPlayers = _clashService.GetActiveClashPlayers(region, summonerId);

            if (clashPlayers == null)
            {
                return BadRequest();
            }

            return Ok(clashPlayers);
        }
    }
}
