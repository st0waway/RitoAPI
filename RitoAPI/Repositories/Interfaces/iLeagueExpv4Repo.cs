using RitoAPI.Models;

namespace RitoAPI.Repositories.Interfaces
{
    interface iLeagueExpv4Repo
    {
        LeagueEntryDTO GetLeagueExp(string queue, string tier, string division);
    }
}
