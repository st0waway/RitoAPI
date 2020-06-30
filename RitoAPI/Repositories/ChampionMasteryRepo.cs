using Microsoft.Extensions.Options;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;

namespace RitoAPI.Repositories
{
    public class ChampionMasteryRepo : iChampionMasteryRepo
    {
        private readonly string _apiKey;

        public ChampionMasteryRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
    }
}
