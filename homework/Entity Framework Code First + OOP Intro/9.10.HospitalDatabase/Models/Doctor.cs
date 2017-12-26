using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.HospitalDatabase.Models
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(20)]
        public string Name { get; set; }
        [Required, MinLength(8)]
        public string Specialty { get; set; }

        private ICollection<Visitation> visitations;

        public Doctor()
        {
            this.visitations = new HashSet<Visitation>();
        }

        public virtual ICollection<Visitation> Visitations
        {
            get { return this.visitations; }
            set { this.visitations = value; }
        }
    }
}
