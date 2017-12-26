using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using _2.AdvancedMapping.Data;
using _2.AdvancedMapping.DTOs;
using _2.AdvancedMapping.Models;

namespace _2.AdvancedMapping
{
    class AdvancedMapping
    {
        static void Main(string[] args)
        {
            ConfigureAutomapping();
            using (EmployeeContext context = new EmployeeContext())
            {
                context.Database.Initialize(true);
            }
            //// 2.	Advanced Mapping
            //IEnumerable<Employee> managers = CreateManagers();
            //IEnumerable<ManagerDTO> managerDTOs = 
            //    Mapper.Map<IEnumerable<Employee>, IEnumerable<ManagerDTO>>(managers);
            //foreach (ManagerDTO managerDTO in managerDTOs)
            //{
            //    Console.WriteLine(managerDTO.ToString());
            //}

            //// 3. Projection
            using (EmployeeContext context = new EmployeeContext())
            {
                context.Employees.Add(new Employee
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "ul.1",
                    Salary = 100M,
                    BirthDate = new DateTime(1979, 3, 2),
                    EmployeesInChargeOf = new List<Employee>(),
                    IsOnHoliday = false,
                    Manager = new Employee { FirstName = "Ivan", LastName = "Ivanov", Salary = 100M }
                });
                context.Employees.Add(new Employee
                {
                    FirstName = "Misho",
                    LastName = "Mishev",
                    Address = "ul.2",
                    Salary = 100M,
                    BirthDate = new DateTime(1978, 1, 5),
                    EmployeesInChargeOf = new List<Employee>(),
                    IsOnHoliday = true,
                    Manager = null
                });
                context.SaveChanges();

                var employees = context.Employees
                                .Where(emp => emp.BirthDate.Value.Year < 1980)
                                .OrderByDescending(emp => emp.Salary)
                                .ProjectTo <EmployeeDTO>();

                foreach (EmployeeDTO emp in employees)
                {
                    Console.WriteLine(emp.ToString());
                }
            }
        }

        private static void ConfigureAutomapping()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dto => dto.ManagerLastName, configExpression => configExpression.MapFrom(e => e.Manager.LastName));
                action.CreateMap<Employee, ManagerDTO>()
                    .ForMember(dto => dto.EmployeesInChargeOfCount,
                        configExpression => configExpression.MapFrom(e => e.EmployeesInChargeOf.Count));
            });
        }

        private static IEnumerable<Employee> CreateManagers() // For Second Problem
        {
            var managers = new List<Employee>();
            for (int i = 0; i < 3; i++)
            {
                var manager = new Employee
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "ul.1",
                    BirthDate = new DateTime(1992, 3, 2),
                    EmployeesInChargeOf = new List<Employee>(),
                    IsOnHoliday = false,
                    Manager = new Employee { FirstName = "Ivan", LastName = "Ivanov", Salary = 1000M},
                    Salary = 100M
                };

                var emp1 = new Employee
                {
                    FirstName = "Tisho",
                    LastName = "Tishev",
                    Salary = 150M,
                    Manager = manager
                };
                var emp2 = new Employee
                {
                    FirstName = "Misho",
                    LastName = "Mishev",
                    Salary = 250M,
                    Manager = manager
                };
                var emp3 = new Employee
                {
                    FirstName = "Kiro",
                    LastName = "Kirov",
                    Salary = 200M,
                    Manager = manager
                };
                manager.EmployeesInChargeOf.Add(emp1);
                manager.EmployeesInChargeOf.Add(emp2);
                manager.EmployeesInChargeOf.Add(emp3);
                managers.Add(manager);
            }

            return managers;
        }
    }
}
