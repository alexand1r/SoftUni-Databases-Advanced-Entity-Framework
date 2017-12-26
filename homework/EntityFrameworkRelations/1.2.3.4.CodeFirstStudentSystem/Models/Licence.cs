using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CodeFirstStudentSystem.Models
{
    public class Licence
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResourceId { get; set; }
        [ForeignKey("ResourceId")]
        public virtual Resource Resource { get; set; }
    }
}
