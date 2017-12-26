using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public enum Role
    {
        Owner, Client
    }
    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }
        [Key]
        public int Id { get; set; }
        public Role Role { get; set; }
        [MinLength(5)]
        public string Username { get; set; }
        [MinLength(3)]
        public string Password { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
