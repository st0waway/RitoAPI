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

		[Fact]
		public void GetLeagueStatus()
		{
			var service = (LolStatusService)_factory.Services.GetService(typeof(LolStatusService));
			var shardStatus = service.GetLeagueStatus("euw1");
			Assert.IsType<ShardStatus>(shardStatus);
			Assert.Equal("prod.euw1.lol.riotgames.com", shardStatus.hostname);
			Assert.Equal("EU West", shardStatus.name);
			Assert.Equal("eu", shardStatus.region_tag);
			Assert.Equal("euw", shardStatus.slug);
		}
	}
}