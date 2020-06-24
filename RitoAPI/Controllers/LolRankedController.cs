using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("leaderboards")]
    [ApiController]
    public class LolRankedController : ControllerBase
    {
        private readonly LolRankedRepo _repository;

        public LolRankedController(LolRankedRepo lolRankedv1Repo)
        {
            _repository = lolRankedv1Repo;
        }

        [HttpGet]
        public ActionResult<LeaderboardDto> GetPlayersInMasterTier(string region = "europe")
        {
            var players= _repository.GetPlayersInMasterTier(region);
            if (players != null)
            {
                return Ok(players);
            }
            else
            {
                return NotFound();
            }
        }
    }
}