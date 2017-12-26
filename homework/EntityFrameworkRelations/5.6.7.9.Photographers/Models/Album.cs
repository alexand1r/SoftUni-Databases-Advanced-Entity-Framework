using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Photographers = new HashSet<Photographer>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string BackgroundColor { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public int PhotographerId { get; set; }
        [ForeignKey("PhotographerId")]
        public virtual ICollection<Photographer> Photographers { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
