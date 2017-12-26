using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class Promotion
    {
        public Promotion()
        {
            this.Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Discount { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
