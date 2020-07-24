using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class LolRankedServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public LolRankedServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetPlayersInMasterTier()
		{
			var service = (LolRankedService)_factory.Services.GetService(typeof(LolRankedService));
			var players = service.GetPlayersInMasterTier("europe");
			Assert.IsType<LeaderboardDto>(players);
			Assert.Equal(0, players.players[0].rank);
			Assert.Equal(1, players.players[1].rank);
			Assert.Equal(2, players.players[2].rank);
			Assert.Equal(3, players.players[3].rank);
			Assert.Equal(4, players.players[4].rank);
		}
	}
}