using System.ComponentModel.DataAnnotations;
using _2.AdvancedMapping.Models;

namespace _2.AdvancedMapping.DTOs
{
    public class EmployeeDTO
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagerLastName { get; set; }

        public override string ToString()
        {
            //// 2. Advanced Mapping
            //return $"    - {FirstName} {LastName} {Salary:F2}";
            //// 3. Projection
            return $"- {FirstName} {LastName} {Salary:F2} - Manager: {ManagerLastName ?? "[no manager]"}";
        }
    }
}
