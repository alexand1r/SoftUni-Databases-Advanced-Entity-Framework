using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2.AdvancedMapping.DTOs
{
    public class ManagerDTO
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<EmployeeDTO> EmployeesInChargeOf { get; set; }
        public int EmployeesInChargeOfCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName} | Employees: {this.EmployeesInChargeOfCount}");
            foreach (var emp in EmployeesInChargeOf)
            {
                sb.AppendLine(emp.ToString());
            }

            return sb.ToString();
        }
    }
}
