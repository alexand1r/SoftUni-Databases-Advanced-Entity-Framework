using System.ComponentModel.DataAnnotations;

namespace _3.SalesDatabase.Models
{
    using System.Collections.Generic;
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
        public ICollection<Sale> SalesInStore { get; set; }
    }
}
