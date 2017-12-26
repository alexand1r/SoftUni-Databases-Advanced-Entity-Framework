using System;
using System.ComponentModel.DataAnnotations;

namespace _1.SimpleMapping.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
    }
}
