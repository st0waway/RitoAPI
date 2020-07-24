using Microsoft.AspNetCore.Mvc.Testing;

using RitoAPI.Models;
using RitoAPI.Services;

using Xunit;

namespace RitoAPI.Tests
{
	public class MatchServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public MatchServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("euw1", "NGh2899uPTAjNcpigwqbR9jlOqaJovDEtUhE4GTjzb7DdKA")]
		[InlineData("na1", "cMeedg7QLIaH2e71EpImpBmgiOcWVjzY6H7ubcQh9a2dVTI")]
		[InlineData("ru", "vATAfvw3BMbMKky6iMHtghHgAovcphQ8xxHmvK8yj_H9jhKhEzlPYAug")]
		[InlineData("oc1", "xaU9a1WoFS6SX3IpwNyoMgjHitwYKxxg89BsQx8vdJQWvuI")]
		[InlineData("jp1", "fnscZct1rXvfjLWPzta9VDAzeonQEWXct9N6eXQHbHV3YaIGIXvinyTx")]
		public void GetMatchlistByAccountId_AccountHas100Games(string region, string accountId)
		{
			var expected = 100;
			
			var service = (MatchService)_factory.Services.GetService(typeof(MatchService));
			var gamesOnAccount = service.GetMatchlistByAccountId(region, accountId);
			var actual = gamesOnAccount.matches.Count;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("euw1", "NGh2899uPTAjNcpigwqbR9jlOqaJovDEtUhE4GTjzb7DdKA")]
		[InlineData("na1", "cMeedg7QLIaH2e71EpImpBmgiOcWVjzY6H7ubcQh9a2dVTI")]
		[InlineData("ru", "vATAfvw3BMbMKky6iMHtghHgAovcphQ8xxHmvK8yj_H9jhKhEzlPYAug")]
		[InlineData("oc1", "xaU9a1WoFS6SX3IpwNyoMgjHitwYKxxg89BsQx8vdJQWvuI")]
		[InlineData("jp1", "fnscZct1rXvfjLWPzta9VDAzeonQEWXct9N6eXQHbHV3YaIGIXvinyTx")]
		public void GetMatchByMatchId_ReturnsAMatch(string region, string accountId)
		{
			var service = (MatchService)_factory.Services.GetService(typeof(MatchService));
			var gamesOnAccount = service.GetMatchlistByAccountId(region, accountId);
			var match = service.GetMatchByMatchId(gamesOnAccount.matches[0].platformId, gamesOnAccount.matches[0].gameId.ToString());

			Assert.IsType<MatchDto>(match);
		}
	}
}