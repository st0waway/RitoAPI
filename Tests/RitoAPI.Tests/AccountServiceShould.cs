using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class AccountServiceShould : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public AccountServiceShould(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Fact]
		public void GetAccountByPuuid()
		{
			var service = (AccountService)_factory.Services.GetService(typeof(AccountService));
			var account = service.GetAccountByPuuid("europe", "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA");
			Assert.Equal("Lum1x", account.gameName);
			Assert.Equal("6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA", account.puuid);
			Assert.Equal("EUW", account.tagLine);
		}

		[Fact]
		public void GetAccountByRiotId()
		{
			var service = (AccountService)_factory.Services.GetService(typeof(AccountService));
			var account = service.GetAccountByRiotId("europe", "Lum1x", "EUW");
			Assert.Equal("Lum1x", account.gameName);
			Assert.Equal("6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA", account.puuid);
			Assert.Equal("EUW", account.tagLine);
		}

		[Fact]
		public void GetActiveShardForPlayer()
		{
			var service = (AccountService)_factory.Services.GetService(typeof(AccountService));
			var activeShardInfo = service.GetActiveShardForPlayer("europe", "val", "6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA");
			Assert.Equal("eu", activeShardInfo.activeShard);
			Assert.Equal("6N57LsQo6kOBNuz8yK8_lJ0KJmEzSH5cF2OhOfmwpQIOza2sZPb_vMb75A0wwdYSONBX26iNMburSA", activeShardInfo.puuid);
			Assert.Equal("val", activeShardInfo.game);
		}
	}
}