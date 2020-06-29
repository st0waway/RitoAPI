using Microsoft.Extensions.Options;
using RitoAPI.Models;

namespace RitoAPI.Repositories
{
    public class SpectatorRepo
    {
        private readonly string _apiKey;

        public SpectatorRepo(IOptions<UserConfig> userConfigAccessor)
        {
            _apiKey = userConfigAccessor.Value.APIKey;
        }
    }
}
