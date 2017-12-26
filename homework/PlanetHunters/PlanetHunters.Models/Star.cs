using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetHunters.Models
{
    public class Star
    {
        private int temperature;
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int Temperature
        {
            get { return temperature; }
            set
            {
                if (value >= 2400) temperature = value;
            }
        }

        public int StarSystemId { get; set; }
        [ForeignKey("StarSystemId")]
        public virtual StarSystem StarSystem { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}
