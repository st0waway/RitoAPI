using Microsoft.Extensions.Options;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;

namespace RitoAPI.Repositories
{
    public class ChampionRepo : iChampionRepo
    {
        private readonly string _apiKey;

        public ChampionRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        } 
    }
}
