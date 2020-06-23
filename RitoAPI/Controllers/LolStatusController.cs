using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("status")]
    [ApiController]
    public class LolStatusController : ControllerBase
    {
        private readonly LolStatusRepo _repository;

        public LolStatusController(LolStatusRepo lolStatusRepo)
        {
            _repository = lolStatusRepo;
        }

        [HttpGet]
        public ActionResult<ShardStatus> GetLeagueStatus(string server = "EUW1")
        {
            var players = _repository.GetLeagueStatus(server);
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