using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Numerics;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Parts = new List<Part>();
        }
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
