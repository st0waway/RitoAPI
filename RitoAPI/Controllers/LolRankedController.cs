using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [Route("leaderboards")]
    [ApiController]
    public class LolRankedController : ControllerBase
    {
        private LolRankedService _lolRankedService;

        public LolRankedController(LolRankedService lolRankedService)
        {
            _lolRankedService = lolRankedService;
        }

        [HttpGet("/by-region/{region}")]
        public IActionResult GetPlayersInMasterTier(string region = "europe")
        {
            var playersInMasterTier = _lolRankedService.GetPlayersInMasterTier(region);

            if (playersInMasterTier == null)
            {
                return BadRequest();
            }

            return Ok(playersInMasterTier);
        }
    }
}