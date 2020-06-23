
using RitoAPI.Models;

namespace RitoAPI.Repositories.Interfaces
{
    interface iLolRankedv1Repo
    {
        LeaderboardDto GetPlayersInMasterTier(string region);
    }
}
