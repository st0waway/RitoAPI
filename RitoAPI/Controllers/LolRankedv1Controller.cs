using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("leaderboards")]
    [ApiController]
    public class LolRankedv1Controller : ControllerBase
    {
        private readonly LolRankedv1Repo _repository;

        public LolRankedv1Controller(LolRankedv1Repo lolRankedv1Repo)
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