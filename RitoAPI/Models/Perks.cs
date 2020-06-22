using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class Perks
    {
        public List<long> perkIds { get; set; }
        public long perkStyle { get; set; }
        public long perkSubStyle { get; set; }
    }
}
