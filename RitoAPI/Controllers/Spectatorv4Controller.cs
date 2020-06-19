using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{
    [Route("spectate")]
    [ApiController]
    public class Spectatorv4Controller : ControllerBase
    {
        private readonly Spectatorv4Repo _repository;

        public Spectatorv4Controller(Spectatorv4Repo spectatorv4Repo)
        {
            _repository = spectatorv4Repo;
        }

        [HttpGet("{encryptedSummonerId}")]
        public ActionResult<CurrentGameInfo> GetGameInfo(string encryptedSummonerId = "2m8N_hWDzBOQ9JHiLoy8KXEZ91ph4IcC_j48gbrJC8_n-sI")
        {
            var gameInfo = _repository.GetGameInfo(encryptedSummonerId);
            if (gameInfo != null)
            {
                return Ok(gameInfo);
            }
            else
            {
                return NotFound();
            }
        }
    }
}