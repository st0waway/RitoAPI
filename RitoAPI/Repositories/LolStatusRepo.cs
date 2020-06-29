using Microsoft.Extensions.Options;
using RitoAPI.Models;
using RitoAPI.Repositories.Interfaces;

namespace RitoAPI.Repositories
{
    public class LolStatusRepo : iLolStatusRepo
    {
        private readonly string _apiKey;

        public LolStatusRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
    }
}
