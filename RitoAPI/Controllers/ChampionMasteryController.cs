using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using RitoAPI.Repositories;
using RitoAPI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RitoAPI.Controllers
{
	[Route("champion-masteries")]
	[ApiController]
	public class ChampionMasteryController : ControllerBase
	{
		private ChampionMasteryService _championMasteryService;

		public ChampionMasteryController(ChampionMasteryService championMasteryService)
		{
			_championMasteryService = championMasteryService;
		}

		[HttpGet("by-summoner/{encryptedSummonerId}")]
		public IActionResult GetChamcpionMasteryBySummoner(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			var championMasteries = _championMasteryService.GetChamcpionMasteryBySummoner(encryptedSummonerId);

			if (championMasteries == null)
			{
				return BadRequest();
			}

			return Ok(championMasteries);
		}

		[HttpGet("by-summoner/{encryptedSummonerId}/by-champion/{championId}")]
		public IActionResult GetChampionMasteryByPlayerIDandChampionID(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk", long championId = 1)
		{
			var championMasteries = _championMasteryService.GetChampionMasteryByPlayerIDandChampionID(encryptedSummonerId, championId);

			if (championMasteries == null)
			{
				return BadRequest();
			}

			return Ok(championMasteries);
		}

		[HttpGet("scores/{encryptedSummonerId}")]
		public IActionResult GetChampionMasteryScore(string encryptedSummonerId = "ohb-yL5WsfR7pAh0psgAspPTBh3MuN2vdNIMxNC02AE2QVk")
		{
			try
			{
				var championMasteries = _championMasteryService.GetChampionMasteryScore(encryptedSummonerId);
				return Ok(championMasteries);
			}
			catch (InvalidDataException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}
	}
}
