using System.ComponentModel.DataAnnotations;

namespace _3.SalesDatabase.Models
{
    using System;
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public StoreLocation StoreLocation { get; set; }
        public DateTime Date { get; set; }
    }
}
