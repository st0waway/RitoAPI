using Microsoft.AspNetCore.Mvc.Testing;

using RitoAPI.Services;

using Xunit;

namespace RitoAPI.Tests
{
	public class LeagueExpServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public LeagueExpServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("JP1", "RANKED_SOLO_5x5", "IRON", "IV")]
		[InlineData("LA1", "RANKED_SOLO_5x5", "SILVER", "III")]
		[InlineData("EUW1", "RANKED_SOLO_5x5", "GOLD", "IV")]
		[InlineData("RU", "RANKED_SOLO_5x5", "MASTER", "I")]
		[InlineData("KR", "RANKED_SOLO_5x5", "CHALLENGER", "I")]
		public void GetLeagueExp_ReturnsPlayersFromCorrectTier(string region, string queue, string tier, string division)
		{
			var expected = tier;

			var service = (LeagueExpService)_factory.Services.GetService(typeof(LeagueExpService));
			var leagueQueueEntry = service.GetLeagueExp(region, queue, tier, division);
			var actual = leagueQueueEntry[0].tier;

			Assert.Equal(expected, actual);
		}
	}
}
