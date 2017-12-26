using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
