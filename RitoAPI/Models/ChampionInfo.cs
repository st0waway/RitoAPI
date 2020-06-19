using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class ChampionInfo
    {
        public int maxNewPlayerLevel { get; set; }
        public List<int> freeChampionIdsForNewPlayers { get; set; }
        public List<int> freeChampionIds { get; set; }
    }
}
