using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("clash")]
    [ApiController]
    public class Clashv1Controller : ControllerBase
    {
        private readonly Clashv1Repo _repository;

        public Clashv1Controller(Clashv1Repo clashv1Repo)
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