using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace _1.LocalStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DistributorName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Weight{ get; set; }
        public int Quantity { get; set; }
    }
}
