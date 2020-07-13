using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Models;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class SummonerServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public SummonerServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetSummonerByName()
		{
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerByName("Lumix");
			Assert.IsType<SummonerDTO>(summoner);			
			Assert.Equal("KfujoSa2slNW8QP8ne6AkZb5PNtGK8aSxX80LPJQ6CyOMw", summoner.AccountId);
			Assert.Equal("xgyV-Wuddie5sg_XjTSOPWMM64CVIegtl-8jRpLCQZnYkSg", summoner.Id);
		}
	}
}
