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

        [HttpGet("bySummoner/{summonerId}")]
        public ActionResult<List<ClashPlayerDto>> GetActiveClashPlayers(string summonerId = "")
        {
            var clashPlayers = _clashService.GetActiveClashPlayers(summonerId);

            if (clashPlayers == null)
            {
                return BadRequest();
            }

            return Ok(clashPlayers);
        }
    }
}
