using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual User Client { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
