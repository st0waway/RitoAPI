
using RitoAPI.Models;

namespace RitoAPI.Repositories.Interfaces
{
    interface iLolRankedRepo
    {
        LeaderboardDto GetPlayersInMasterTier(string region);
    }
}
