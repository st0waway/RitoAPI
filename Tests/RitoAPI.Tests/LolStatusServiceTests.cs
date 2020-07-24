using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class LolStatusServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public LolStatusServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("euw1", "prod.euw1.lol.riotgames.com")]
		[InlineData("ru", "prod.ru.lol.riotgames.com")]
		[InlineData("oc1", "prod.oc1.lol.riotgames.com")]
		[InlineData("jp1", "prod.jp1.lol.riotgames.com")]
		[InlineData("na1", "prod.na1.lol.riotgames.com")]
		public void GetLeagueStatus_ReturnsCorrectHostname(string region, string expected)
		{
			var service = (LolStatusService)_factory.Services.GetService(typeof(LolStatusService));
			var shardStatus = service.GetLeagueStatus(region);
			var actual = shardStatus.hostname;

			Assert.Equal(expected, actual);
		}
	}
}