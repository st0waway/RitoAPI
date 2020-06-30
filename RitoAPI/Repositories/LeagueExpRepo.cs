using Microsoft.Extensions.Options;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;

namespace RitoAPI.Repositories
{
    public class LeagueExpRepo : iLeagueExpRepo
    {
        private readonly string _apiKey;

        public LeagueExpRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
    }
}
