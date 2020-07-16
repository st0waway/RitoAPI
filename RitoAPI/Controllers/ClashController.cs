using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("clash")]
    [ApiController]
    public class ClashController : ControllerBase
    {
        private ClashService _clashService;

        public ClashController(ClashService clashService)
        {
            _clashService = clashService;
        }

        [HttpGet("bySummoner/{summonerId}/{region}")]
        public ActionResult<List<ClashPlayerDto>> GetActiveClashPlayers(string region, string summonerId = "")
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
