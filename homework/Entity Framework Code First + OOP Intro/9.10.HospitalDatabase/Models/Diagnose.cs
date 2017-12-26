using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.HospitalDatabase.Models
{
    public class Diagnose
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(20)]
        public string Name { get; set; }

        private ICollection<DiagnoseComment> comments;

        public Diagnose()
        {
            this.comments = new HashSet<DiagnoseComment>();
        }

        public virtual ICollection<DiagnoseComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
