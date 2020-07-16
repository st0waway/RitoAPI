using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RitoAPI.Models;
using System.IO;
using System.Net;

namespace RitoAPI.Services
{
	public class AccountService
	{
		private readonly string _apiKey;

		public AccountService(IOptions<UserConfig> userConfigAccessor)
		{
			_apiKey = userConfigAccessor.Value.APIKey;
		}

		public AccountDto GetAccountByPuuid(string region, string puuid)
		{
			var url = "https://" + region + ".api.riotgames.com/riot/account/v1/accounts/by-puuid/" + puuid + "?api_key=" + _apiKey;

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;

				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var accountAsJson = streamReader.ReadToEnd();
						var account = JsonConvert.DeserializeObject<AccountDto>(accountAsJson);
						return account;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		public AccountDto GetAccountByRiotId(string region, string gameName, string tagLine)
		{
			var url = "https://" + region + ".api.riotgames.com/riot/account/v1/accounts/by-riot-id/"+ gameName + "/" + tagLine + "?api_key=" + _apiKey;

			try
			{
				var request = WebRequest.Create(url) as HttpWebRequest;

				using (var stream = request.GetResponse().GetResponseStream())
				{
					using (var streamReader = new StreamReader(stream))
					{
						var accountAsJson = streamReader.ReadToEnd();
						var account = JsonConvert.DeserializeObject<AccountDto>(accountAsJson);
						return account;
					}
				}
			}
			catch (WebException)
			{
				return null;
			}
		}		
	}
}
