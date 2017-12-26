using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class Product
    {
        public Product()
        {
            this.Ingredients = new List<Ingredient>();
            this.Categories = new List<Category>();
            this.Orders = new List<Order>();
            this.Promotions = new List<Promotion>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPromoted { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
