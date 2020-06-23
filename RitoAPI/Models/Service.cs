using System.Collections.Generic;

namespace RitoAPI.Models
{
    public class Service
    {
        public List<Incident> incidents { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string status { get; set; }

    }
}
