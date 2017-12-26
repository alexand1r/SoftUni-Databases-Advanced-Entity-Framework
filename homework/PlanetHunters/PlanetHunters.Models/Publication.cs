using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Publication
    {
        public int Id { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public int DiscoveryId { get; set; }
        [ForeignKey("DiscoveryId")]
        [Required]
        public virtual Discovery Discovery { get; set; }
    }
}
