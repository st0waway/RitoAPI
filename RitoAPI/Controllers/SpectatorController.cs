using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
    [ApiController]
    public class SpectatorController : ControllerBase
    {
        private SpectatorService _spectatorService;

        public SpectatorController(SpectatorService spectatorService)
        {
            _spectatorService = spectatorService;
        }

        [HttpGet("spectate/{id}")]
        public IActionResult GetGameInfo(string id = "fYjvBkqrZjvJ54r6tpH0wY2-CoNQFc5lIW92E-nFnUClTPE")
        {
            var gameInfo = _spectatorService.GetGameInfo(id);

            if (gameInfo == null)
            {
                return BadRequest();
            }

            return Ok(gameInfo);
        }

        [HttpGet("featured-games")]
        public IActionResult GetFeaturedGames()
        {
            var featuredGamesInfo = _spectatorService.GetFeaturedGames();

            if (featuredGamesInfo == null)
            {
                return BadRequest();
            }

            return Ok(featuredGamesInfo);
        }
    }
}