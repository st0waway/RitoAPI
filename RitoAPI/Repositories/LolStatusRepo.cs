using Microsoft.Extensions.Options;
using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    public class LolStatusRepo
    {
        private readonly string _apiKey;

        public LolStatusRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
    }
}
