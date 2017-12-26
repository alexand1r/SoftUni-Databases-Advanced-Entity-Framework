using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Product
    {
        public Product()
        {
            Categories = new List<Category>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual User Buyer { get; set; }
        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
