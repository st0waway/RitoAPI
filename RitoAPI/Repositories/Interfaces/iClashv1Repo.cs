using RitoAPI.Models;
using System.Collections.Generic;

namespace RitoAPI.Repositories.Interfaces
{
    interface iClashv1Repo
    {
        List<ClashPlayerDto> GetLeagueExp(string summonerId);
    }
}
