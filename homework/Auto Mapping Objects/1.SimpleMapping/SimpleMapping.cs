using System;
using System.Linq;
using AutoMapper;
using _1.SimpleMapping.Data;
using _1.SimpleMapping.Models;

namespace _1.SimpleMapping
{
    class SimpleMapping
    {
        static void Main(string[] args)
        {
            var context = new EmployeeContext();
            context.Database.Initialize(true);
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());

            var addEmp = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Salary = 1000M
            };
            context.Employees.Add(addEmp);
            context.SaveChanges();

            var employee = context.Employees.FirstOrDefault();
            EmployeeDto dto = Mapper.Map<EmployeeDto>(employee);

            Console.WriteLine($"{dto.FirstName} - {dto.LastName} - {dto.Salary}");
        }

        public class EmployeeDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal Salary { get; set; }
        }
    }
}
