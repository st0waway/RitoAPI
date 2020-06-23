using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class ShardStatus
    {
        public List<string> locales { get; set; }
        public string hostname { get; set; }
        public string name { get; set; }
        public List<Service> services { get; set; }
        public string slug { get; set; }
        public string region_tag { get; set; }

    }
}
