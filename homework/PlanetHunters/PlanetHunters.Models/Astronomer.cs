using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetHunters.Models
{
    public class Astronomer
    {
        public Astronomer()
        {
            this.PioneerDiscoveries = new HashSet<Discovery>();
            this.ObserverDiscoveries = new HashSet<Discovery>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public virtual ICollection<Discovery> PioneerDiscoveries { get; set; }
        public virtual ICollection<Discovery> ObserverDiscoveries { get; set; }
    }
}
