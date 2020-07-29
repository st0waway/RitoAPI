using Microsoft.AspNetCore.Mvc.Testing;
using RitoAPI.Services;
using Xunit;

namespace RitoAPI.Tests
{
	public class AccountServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public AccountServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("europe", "9HtsonXM5dtY39cbySr3kHLRlTcqFkv3PTRAH5VjEOyLmLGLNLAvlRhM1pNu02OB9c0YnXDQHU7MLQ", "RGE lnspired")]
		[InlineData("americas", "wM14gJ-e7QxYFSj7gUOuTGEwMz_Ec5P3hNx878j8L6sLa7lPSRAwGJVHXKARSVfhY4tH-UJeAveOsw", "C9 Zven")]
		[InlineData("europe", "fKO_k0LRkgyeXvma1n7Ih7o5aWdirDn74-1XIGEgUdtSTASIOe7NrCG6IY1MYaqO6OJGRgUonTvYjw", "Choke on my Fizz")]
		[InlineData("asia", "IUnVydyblwcuuwg_4KJ6iuWY48JR4m4EuU1ppcbXRU70gptArBiC-K4Fj4w0HW4no_lTowOVkqLpLg", "gunkrab")]
		[InlineData("asia", "7ndTViYQHGMMgTuKUGNXvkekrRP9k31MvjkW0nk6j7v2W0DLi5x7aKV5OTygUuKWH6kuubaJEnxdbg", "biewanad")]
		public void GetAccountByPuuid_ShouldHaveExpectedName(string region, string puuid, string gameName)
		{
			var expected = gameName;

			var service = (AccountService)_factory.Services.GetService(typeof(AccountService));
			var account = service.GetAccountByPuuid(region, puuid);
			var actual = account.gameName;

			Assert.Equal(expected, actual);
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

		[Theory]
		[InlineData("europe", "val", "9HtsonXM5dtY39cbySr3kHLRlTcqFkv3PTRAH5VjEOyLmLGLNLAvlRhM1pNu02OB9c0YnXDQHU7MLQ")]
		[InlineData("americas", "val", "wM14gJ-e7QxYFSj7gUOuTGEwMz_Ec5P3hNx878j8L6sLa7lPSRAwGJVHXKARSVfhY4tH-UJeAveOsw")]
		[InlineData("europe", "val", "fKO_k0LRkgyeXvma1n7Ih7o5aWdirDn74-1XIGEgUdtSTASIOe7NrCG6IY1MYaqO6OJGRgUonTvYjw")]
		[InlineData("asia", "val", "IUnVydyblwcuuwg_4KJ6iuWY48JR4m4EuU1ppcbXRU70gptArBiC-K4Fj4w0HW4no_lTowOVkqLpLg")]
		[InlineData("asia", "val", "7ndTViYQHGMMgTuKUGNXvkekrRP9k31MvjkW0nk6j7v2W0DLi5x7aKV5OTygUuKWH6kuubaJEnxdbg")]
		public void GetActiveShardForPlayer_ReturnsCorrectPUUID(string requestRegion, string game, string puuid)
		{
			var expected = puuid;

			var service = (AccountService)_factory.Services.GetService(typeof(AccountService));
			var activeShardInfo = service.GetActiveShardForPlayer(requestRegion, game, puuid);
			var actual = activeShardInfo.puuid;

			Assert.Equal(expected, actual);			
		}
	}
}