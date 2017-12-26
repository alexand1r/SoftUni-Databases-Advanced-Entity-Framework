using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class User
    {
        public User()
        {
            SelledProducts = new List<Product>();
            BoughtProducts = new List<Product>();
            Friends = new List<User>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }
        [InverseProperty("Seller")]
        public virtual ICollection<Product> SelledProducts { get; set; }
        [InverseProperty("Buyer")]
        public virtual ICollection<Product> BoughtProducts { get; set; }
        public virtual ICollection<User> Friends { get; set; }
    }
}
