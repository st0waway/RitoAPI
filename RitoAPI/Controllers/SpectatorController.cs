using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [ApiController]
    public class SpectatorController : ControllerBase
    {
        private SpectatorService _spectatorService;
        private readonly ILogger<SpectatorController> _logger;

        public SpectatorController(SpectatorService spectatorService, ILogger<SpectatorController> logger)
        {
            _spectatorService = spectatorService;
            _logger = logger;
        }

        [HttpGet("spectate/{id}/{region}")]
        public IActionResult GetGameInfo(string region = "euw1",string id = "fYjvBkqrZjvJ54r6tpH0wY2-CoNQFc5lIW92E-nFnUClTPE")
        {
            _logger.LogInformation("GetGameInfo, region = {region}, id = {id}", region, id);
            var gameInfo = _spectatorService.GetGameInfo(region, id);

            if (gameInfo == null)
            {
                return BadRequest();
            }

            return Ok(gameInfo);
        }

        [HttpGet("featured-games/{region}")]
        public IActionResult GetFeaturedGames(string region = "euw1")
        {
            _logger.LogInformation("GetFeaturedGames, region = {region}", region);
            var featuredGamesInfo = _spectatorService.GetFeaturedGames(region);

            if (featuredGamesInfo == null)
            {
                return BadRequest();
            }

            return Ok(featuredGamesInfo);
        }
    }
}