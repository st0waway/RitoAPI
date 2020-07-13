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
			var summoner = service.GetSummonerByName("LumiX");
			Assert.IsType<SummonerDTO>(summoner);			
			Assert.Equal("KfujoSa2slNW8QP8ne6AkZb5PNtGK8aSxX80LPJQ6CyOMw", summoner.AccountId);
			Assert.Equal("xgyV-Wuddie5sg_XjTSOPWMM64CVIegtl-8jRpLCQZnYkSg", summoner.Id);
			Assert.Equal("uTkDriAmEwNbyev-RAdu8mppfJyrVhL393CvxYp6OMt0IyL4OzeYHVN9nbQMtpPhcIKmpJSfRjuDJg", summoner.Puuid);
		}

		[Fact]
		public void GetSummonerByAccount()
		{
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerByAccount("KfujoSa2slNW8QP8ne6AkZb5PNtGK8aSxX80LPJQ6CyOMw");
			Assert.IsType<SummonerDTO>(summoner);
			Assert.Equal("LumiX", summoner.Name);
			Assert.Equal("xgyV-Wuddie5sg_XjTSOPWMM64CVIegtl-8jRpLCQZnYkSg", summoner.Id);
			Assert.Equal("uTkDriAmEwNbyev-RAdu8mppfJyrVhL393CvxYp6OMt0IyL4OzeYHVN9nbQMtpPhcIKmpJSfRjuDJg", summoner.Puuid);
		}

		[Fact]
		public void GetSummonerByPUUID()
		{
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerByPUUID("uTkDriAmEwNbyev-RAdu8mppfJyrVhL393CvxYp6OMt0IyL4OzeYHVN9nbQMtpPhcIKmpJSfRjuDJg");
			Assert.IsType<SummonerDTO>(summoner);
			Assert.Equal("LumiX", summoner.Name);
			Assert.Equal("KfujoSa2slNW8QP8ne6AkZb5PNtGK8aSxX80LPJQ6CyOMw", summoner.AccountId);
			Assert.Equal("xgyV-Wuddie5sg_XjTSOPWMM64CVIegtl-8jRpLCQZnYkSg", summoner.Id);
		}
	}
}
