using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CreateUser
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(4), MaxLength(30)]
        public string Username { get; set; }
        [MinLength(6), MaxLength(50), Required, 
            RegularExpression("^(?=.{6,50})(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@!#)(?>_*<$%^&+]).*$")]
        public string Password { get; set; }
        [RegularExpression("^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$")]
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime LastTimeLoggedIn { get; set; }
        [Range(1, 120)]
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
    }
}
