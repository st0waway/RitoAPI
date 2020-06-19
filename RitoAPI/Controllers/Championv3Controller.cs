using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;

namespace RitoAPI.Controllers
{    
    [ApiController]
    public class Championv3Controller : ControllerBase
    {
        private readonly Championv3Repo _repository = new Championv3Repo();

        [HttpGet("champion-rotations")]
        public ActionResult<ChampionInfo> GetChampionInfo()
        {
            var championInfo = _repository.GetChampionInfo();
            if (championInfo != null)
            {
                return Ok(championInfo);
            }
            else
            {
                return NotFound();
            }
        }
    }
}