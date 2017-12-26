using _2.AdvancedMapping.DTOs;
using _2.AdvancedMapping.Models;

namespace _2.AdvancedMapping.Data
{
    using System.Data.Entity;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext1")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<EmployeeDTO> EmployeesDtos { get; set; }
        //public virtual DbSet<ManagerDTO> ManagerDtos { get; set; }
    }
}