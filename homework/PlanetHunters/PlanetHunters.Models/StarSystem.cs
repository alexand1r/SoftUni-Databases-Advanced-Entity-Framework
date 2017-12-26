using System.Collections.Generic;

namespace PlanetHunters.Models
{
    public class StarSystem
    {
        public StarSystem()
        {
            this.Planets = new HashSet<Planet>();
            this.Stars = new HashSet<Star>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
    }
}
