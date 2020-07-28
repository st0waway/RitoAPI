using Microsoft.AspNetCore.Mvc.Testing;

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

		[Theory]
		[InlineData("AMERICAS", 0)]
		[InlineData("ASIA", 1)]
		[InlineData("EUROPE", 5)]
		[InlineData("SEA", 10)]
		public void GetPlayersInMasterTier_ReturnsCorrectRank(string region, int rank)
		{
			var expected = rank;

			var service = (LolRankedService)_factory.Services.GetService(typeof(LolRankedService));
			var players = service.GetPlayersInMasterTier(region);
			var actual = players.players[rank].rank;
						
			Assert.Equal(expected, actual);			
		}
	}
}