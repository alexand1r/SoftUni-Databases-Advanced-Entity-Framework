using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetHunters.Models
{
    public class Planet
    {
        private decimal mass;
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public decimal Mass
        {
            get { return mass; }
            set
            {
                if (value > 0.0M) mass = value;
            }
        }

        public int StarSystemId { get; set; }
        [ForeignKey("StarSystemId")]
        public virtual StarSystem StarSystem { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}
