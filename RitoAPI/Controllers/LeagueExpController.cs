﻿using Microsoft.AspNetCore.Mvc;
using RitoAPI.Models;
using RitoAPI.Repositories;
using System.Collections.Generic;

namespace RitoAPI.Controllers
{
    [Route("league-exp")]
    [ApiController]
    public class LeagueExpController : ControllerBase
    {
        private readonly LeagueExpRepo _repository;

        public LeagueExpController(LeagueExpRepo leagueExpv4)
        {
            _repository = leagueExpv4;
        }

        [HttpGet("{queue}/{tier}/{division}")]
        public ActionResult<List<LeagueEntryDTO>> GetLeagueExp(string queue = "RANKED_SOLO_5x5", string tier = "SILVER", string division = "IV")
        {
            var leagueExp = _repository.GetLeagueExp(queue, tier, division);
            if (leagueExp != null)
            {
                return Ok(leagueExp);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
