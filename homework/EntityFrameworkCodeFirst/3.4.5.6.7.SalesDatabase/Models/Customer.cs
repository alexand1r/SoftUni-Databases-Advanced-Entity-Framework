using System.ComponentModel.DataAnnotations;

namespace _3.SalesDatabase.Models
{
    using System.Collections.Generic;
    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<Sale> SalesForCustomer { get; set; }
    }
}
