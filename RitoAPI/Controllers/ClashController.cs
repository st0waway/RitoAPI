using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("clash")]
    [ApiController]
    public class ClashController : ControllerBase
    {
        private readonly ClashRepo _repository;

        public ClashController(ClashRepo clashv1Repo)
        {
            _repository = clashv1Repo;
        }

        [HttpGet("bySummoner/{summonerId}")]
        public ActionResult<List<ClashPlayerDto>> GetActiveClashPlayers(string summonerId = "")
        {
            var players = _repository.GetActiveClashPlayers(summonerId);
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