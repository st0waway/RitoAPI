using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class MatchlistDto
    {
        public int startIndex { get; set; }
        public int totalGames { get; set; }
        public int endIndex { get; set; }
        public List<MatchReferenceDto> matches { get; set; }        
    }
}
