using RitoAPI.Models;
using System.Collections.Generic;

namespace RitoAPI.Repositories.Interfaces
{
    interface iLeagueExpRepo
    {
        List<LeagueEntryDTO> GetLeagueExp(string queue, string tier, string division);
    }
}
