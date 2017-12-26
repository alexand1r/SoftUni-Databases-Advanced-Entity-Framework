using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CodeFirstStudentSystem.Models
{
    public enum TypeOfResource
    {
        Video, Presentation, Document, Other
    }
    public class Resource
    {
        public Resource()
        {
            this.Licences = new HashSet<Licence>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TypeOfResource Type { get; set; }
        [Required]
        public string Url { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public virtual ICollection<Licence> Licences { get; set; }
    }
}
