using Microsoft.AspNetCore.Mvc.Testing;

using RitoAPI.Services;

using Xunit;

namespace RitoAPI.Tests
{
	public class ChampionServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public ChampionServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("br1", 10)]
		[InlineData("euw1", 10)]
		[InlineData("kr", 10)]
		[InlineData("la2", 10)]
		[InlineData("ru", 10)]
		[InlineData("tr1", 10)]
		public void GetFreeChampionInfo_HasMaxNewPlayerLevel10(string region, int level)
		{
			var expected = level;

			var service = (ChampionService)_factory.Services.GetService(typeof(ChampionService));
			var freeChampionRotation = service.GetFreeChampionInfo(region);
			var actual = freeChampionRotation.maxNewPlayerLevel;

			Assert.Equal(expected, actual);
		}
	}
}
