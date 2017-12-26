using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public string Path { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
