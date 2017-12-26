using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(3), MaxLength(15)]
        public string  Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
