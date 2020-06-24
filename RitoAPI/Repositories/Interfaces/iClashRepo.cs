using RitoAPI.Models;
using System.Collections.Generic;

namespace RitoAPI.Repositories.Interfaces
{
    interface iClashRepo
    {
        List<ClashPlayerDto> GetLeagueExp(string summonerId);
    }
}
