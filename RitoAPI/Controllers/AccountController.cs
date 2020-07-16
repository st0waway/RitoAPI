using Microsoft.AspNetCore.Mvc;
using RitoAPI.Services;

namespace RitoAPI.Controllers
{
	[Route("account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private AccountService _accountService;

		public AccountController(AccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet("puuid/{puuid}")]
		public IActionResult GetAccountByPuuid(string region = "europe", string puuid = "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA")
		{
			var summoner = _accountService.GetAccountByPuuid(region, puuid);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}

		[HttpGet("riotid/{gameName}/{tagLine}")]
		public IActionResult GetAccountByRiotId(string region = "europe", string gameName = "Lum1x", string tagLine = "EUW")
		{
			var summoner = _accountService.GetAccountByRiotId(region, gameName, tagLine);

			if (summoner == null)
			{
				return BadRequest();
			}

			return Ok(summoner);
		}
	}
}
