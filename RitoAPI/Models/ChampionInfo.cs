using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RitoAPI.Models
{
    public class ChampionInfo
    {
        public int maxNewPlayerLevel { get; set; }
        public List<int> freeChampionIdsForNewPlayers { get; set; }
        public List<int> freeChampionIds { get; set; }
    }
}
