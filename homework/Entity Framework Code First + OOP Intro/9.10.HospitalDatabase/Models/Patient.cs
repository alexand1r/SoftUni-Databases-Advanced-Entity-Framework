using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.HospitalDatabase.Models
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required, MinLength(6)]
        public string Address { get; set; }
        [RegularExpression("^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Picture { get; set; }
        public bool hasMedicalInsurance { get; set; }

        private ICollection<Visitation> visitations;
        private ICollection<Diagnose> diagnoses;
        private ICollection<Medicament> medicaments;

        public Patient()
        {
            this.visitations = new HashSet<Visitation>();
            this.diagnoses = new HashSet<Diagnose>();
            this.medicaments = new HashSet<Medicament>();
        }

        public virtual ICollection<Visitation> Visitations
        {
            get { return this.visitations; }
            set { this.visitations = value; }
        }
        public virtual ICollection<Diagnose> Diagnoses
        {
            get { return this.diagnoses; }
            set { this.diagnoses = value; }
        }
        public virtual ICollection<Medicament> Medicaments
        {
            get { return this.medicaments; }
            set { this.medicaments = value; }
        }
    }
}
