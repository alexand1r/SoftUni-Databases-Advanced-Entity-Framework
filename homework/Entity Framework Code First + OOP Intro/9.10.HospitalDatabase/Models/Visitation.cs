using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.HospitalDatabase.Models
{
    public class Visitation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(20)]
        public DateTime date { get; set; }
        public virtual Doctor Doctor { get; set; }

        private ICollection<VisitationComment> comments;

        public Visitation()
        {
            this.comments = new HashSet<VisitationComment>();
        }

        public virtual ICollection<VisitationComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
