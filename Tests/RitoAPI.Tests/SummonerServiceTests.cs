using Microsoft.AspNetCore.Mvc.Testing;

using RitoAPI.Services;

using Xunit;

namespace RitoAPI.Tests
{
	public class SummonerServiceTests : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public SummonerServiceTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("euw1", "RGE lnspired", "NGh2899uPTAjNcpigwqbR9jlOqaJovDEtUhE4GTjzb7DdKA")]
		[InlineData("na1", "C9 Zven", "cMeedg7QLIaH2e71EpImpBmgiOcWVjzY6H7ubcQh9a2dVTI")]
		[InlineData("ru", "Teufelslied", "vATAfvw3BMbMKky6iMHtghHgAovcphQ8xxHmvK8yj_H9jhKhEzlPYAug")]
		[InlineData("oc1", "gunkrab", "xaU9a1WoFS6SX3IpwNyoMgjHitwYKxxg89BsQx8vdJQWvuI")]
		[InlineData("jp1", "biewanad", "fnscZct1rXvfjLWPzta9VDAzeonQEWXct9N6eXQHbHV3YaIGIXvinyTx")]
		public void GetSummonerByName_ShouldGetAccountId(string region, string name, string expected)
		{				
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerByName(region, name);
			string actual = summoner.AccountId;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("euw1", "NGh2899uPTAjNcpigwqbR9jlOqaJovDEtUhE4GTjzb7DdKA", "RGE lnspired")]
		[InlineData("na1", "cMeedg7QLIaH2e71EpImpBmgiOcWVjzY6H7ubcQh9a2dVTI", "C9 Zven")]
		[InlineData("ru", "vATAfvw3BMbMKky6iMHtghHgAovcphQ8xxHmvK8yj_H9jhKhEzlPYAug", "Teufelslied")]
		[InlineData("oc1", "xaU9a1WoFS6SX3IpwNyoMgjHitwYKxxg89BsQx8vdJQWvuI", "gunkrab")]
		[InlineData("jp1", "fnscZct1rXvfjLWPzta9VDAzeonQEWXct9N6eXQHbHV3YaIGIXvinyTx","biewanad")]
		public void GetSummonerByAccount_ShouldGetSummonerName(string region, string accountId, string expected)
		{
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerByAccount(region, accountId);
			var actual = summoner.Name;
			
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("euw1", "9HtsonXM5dtY39cbySr3kHLRlTcqFkv3PTRAH5VjEOyLmLGLNLAvlRhM1pNu02OB9c0YnXDQHU7MLQ", "RGE lnspired")]
		[InlineData("na1", "wM14gJ-e7QxYFSj7gUOuTGEwMz_Ec5P3hNx878j8L6sLa7lPSRAwGJVHXKARSVfhY4tH-UJeAveOsw", "C9 Zven")]
		[InlineData("ru", "fKO_k0LRkgyeXvma1n7Ih7o5aWdirDn74-1XIGEgUdtSTASIOe7NrCG6IY1MYaqO6OJGRgUonTvYjw", "Teufelslied")]
		[InlineData("oc1", "IUnVydyblwcuuwg_4KJ6iuWY48JR4m4EuU1ppcbXRU70gptArBiC-K4Fj4w0HW4no_lTowOVkqLpLg", "gunkrab")]
		[InlineData("jp1", "7ndTViYQHGMMgTuKUGNXvkekrRP9k31MvjkW0nk6j7v2W0DLi5x7aKV5OTygUuKWH6kuubaJEnxdbg", "biewanad")]
		public void GetSummonerByPUUID_ShouldGetSummonerName(string region, string puuid, string expected)
		{
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerByPUUID(region, puuid);
			var actual = summoner.Name;
						
			Assert.Equal(expected, actual);			
		}

		[Theory]
		[InlineData("euw1", "gMe0Nt4CpreMJRa9e-8u71tHtS_p-G2WpI5EjFCjjZXUAVk", "RGE lnspired")]
		[InlineData("na1", "R84hfPnFbZbisUxqc75-e4dxzIS99ExnjqACgn7b5xzN1E0", "C9 Zven")]
		[InlineData("ru", "N8kT7Dgjk2_AGCznbanIkSRtRF9U_g3oRCn3BHO-zsWBVwg", "Teufelslied")]
		[InlineData("oc1", "ySQv_pKT-lhCNa-0Swb_Gm7-s7vkTpOCkPZ7QZubHJqq", "gunkrab")]
		[InlineData("jp1", "v7KFUgdLNT49aR6vVyO2zOxbab_INOUwWkOpMJElPYTdPTY", "biewanad")]
		public void GetSummonerBySummonerID_ShouldGetSummonerName(string region, string summonerId, string expected)
		{
			var service = (SummonerService)_factory.Services.GetService(typeof(SummonerService));
			var summoner = service.GetSummonerBySummonerID(region, summonerId);
			var actual = summoner.Name;

			Assert.Equal(expected, actual);		
		}
	}
}
