using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class MatchServiceTest : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public MatchServiceTest(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetMatchlistByAccountId()
		{
			var service = (MatchService)_factory.Services.GetService(typeof(MatchService));
			var gamesOnAccount = service.GetMatchlistByAccountId("euw1", "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI");
			Assert.IsType<MatchlistDto>(gamesOnAccount);
			Assert.Equal(100, gamesOnAccount.matches.Count);
			var topGames = gamesOnAccount.matches.Where(x => x.lane == "TOP");
			Assert.NotEmpty(topGames);
		}

		[Fact]
		public void GetMatchByMatchId()
		{
			var service = (MatchService)_factory.Services.GetService(typeof(MatchService));
			var gamesOnAccount = service.GetMatchlistByAccountId("euw1", "55FIELFqN-ORp2SbiBPMDHE3ZwI4xkZCx3w7eka3SZ6yupI");
			var match = service.GetMatchByMatchId("euw1", gamesOnAccount.matches[0].gameId.ToString());
			Assert.IsType<MatchDto>(match);
		}
	}
}