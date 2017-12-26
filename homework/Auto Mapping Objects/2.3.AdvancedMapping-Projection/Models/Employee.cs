using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2.AdvancedMapping.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesInChargeOf = new List<Employee>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsOnHoliday { get; set; }
        public string Address { get; set; }
        public Employee Manager { get; set; }

        public virtual ICollection<Employee> EmployeesInChargeOf { get; set; }
    }
}
