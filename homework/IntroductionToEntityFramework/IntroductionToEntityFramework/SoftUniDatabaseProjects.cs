using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntroductionToEntityFramework
{
    class SoftUniDatabaseProjects
    {
        static void Main(string[] args)
        {
            SoftUniContent content = new SoftUniContent();

            //---------------------------------------------------------------------------//
            //3. Employees full information                                              //
            //---------------------------------------------------------------------------//
            //var employees = content.Employees.OrderBy(e => e.EmployeeID).ToList();
            //foreach (Employee emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary}");
            //}

            //---------------------------------------------------------------------------//
            //4. Employees with Salary Over 50 000                                       //
            //---------------------------------------------------------------------------//
            //var employees = content.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName);
            //foreach (string empName in employees)
            //{
            //    Console.WriteLine(empName);
            //}

            //---------------------------------------------------------------------------//
            //5. Employees from Seattle                                                  //
            //---------------------------------------------------------------------------//
            //var employees = content.Employees
            //    .Where(e => e.Department.Name == "Research and Development")
            //    .OrderBy(e => e.Salary)
            //    .ThenByDescending(e => e.FirstName)
            //    .ToList();
            //foreach (Employee emp in employees)
            //{
            //    Console.WriteLine(
            //        $"{emp.FirstName} {emp.LastName} from {emp.Department.Name} - ${emp.Salary:F2}");
            //}

            //---------------------------------------------------------------------------//
            //6. Adding a New Address and Updating Employee                              //
            //---------------------------------------------------------------------------//
            //var address = new Address();
            //address.AddressText = "Vitoshka 15";
            //address.TownID = 4;

            //content.Addresses.Add(address);
            //content.SaveChanges();

            //var employee = content.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            //employee.Address = address;
            //content.SaveChanges();

            //var employees = content.Employees
            //    .OrderByDescending(e => e.AddressID)
            //    .Take(10)
            //    .Select(e => e.Address.AddressText);
            //foreach (string addressName in employees)
            //{
            //    Console.WriteLine(addressName);
            //}

            //---------------------------------------------------------------------------//
            //7. Find employees in period                                                //
            //---------------------------------------------------------------------------//
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            //var employyes = content.Employees
            //    .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
            //    .Take(30);
            //foreach (var e in employyes)
            //{
            //    Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
            //    foreach (var p in e.Projects)
            //    {
            //        Console.WriteLine($"--{p.Name} {p.StartDate:M/d/yyyy h:mm:ss tt} {p.EndDate:M/d/yyyy h:mm:ss tt}");
            //    }
            //}

            //---------------------------------------------------------------------------//
            //8. Addresses by town name                                                  //
            //---------------------------------------------------------------------------//
            //var addresses = content.Addresses
            //    .OrderByDescending(a => a.Employees.Count)
            //    .ThenBy(a => a.Town.Name)
            //    .Take(10).ToList();

            //foreach (Address address in addresses)
            //{
            //    Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            //}

            //---------------------------------------------------------------------------//
            //9. Employee with id 147                                                    //
            //---------------------------------------------------------------------------//
            //var employee = content.Employees.Where(e => e.EmployeeID == 147).ToList();
            //foreach (Employee emp in employee)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
            //    var projects = emp.Projects.OrderBy(p => p.Name).ToList();
            //    foreach (Project pr in projects)
            //    {
            //        Console.WriteLine($"{pr.Name}");
            //    }
            //}

            //---------------------------------------------------------------------------//
            //10. Departments with more than 5 employees                                 //
            //---------------------------------------------------------------------------//
            //var departments = content.Departments
            //    .Where(d => d.Employees.Count > 5)
            //    .OrderBy(d => d.Employees.Count).ToList();
            //foreach (Department dep in departments)
            //{
            //    Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
            //    var employees = dep.Employees.ToList();
            //    foreach (Employee emp in employees)
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
            //    }
            //}

            //---------------------------------------------------------------------------//
            //11. Find Latest 10 Projects                                                //
            //---------------------------------------------------------------------------//
            //var projects = content.Projects
            //    .OrderByDescending(p => p.StartDate)
            //    .Take(10)
            //    .ToList();
            //foreach (Project pr in projects.OrderBy(p => p.Name))
            //{
            //    Console.WriteLine(
            //        $"{pr.Name} {pr.Description} {pr.StartDate:M/d/yyyy h:mm:ss tt} {pr.EndDate:M/d/yyyy h:mm:ss tt}");
            //}

            //---------------------------------------------------------------------------//
            //12. Increase Salaries                                                      //
            //---------------------------------------------------------------------------//
            //var employees = content.Employees
            //    .Where(e => e.Department.Name == "Engineering" ||
            //                e.Department.Name == "Tool Design" ||
            //                e.Department.Name == "Marketing" ||
            //                e.Department.Name == "Information Services");
            //foreach (Employee emp in employees)
            //{
            //    emp.Salary *= 1.12M;
            //}

            //content.SaveChanges();

            //foreach (Employee emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F6})");
            //}

            //---------------------------------------------------------------------------//
            //13. Find Employees by First Name starting with SA                          //
            //---------------------------------------------------------------------------//
            //var employees = content.Employees
            //    .Where(e => e.FirstName.ToLower().StartsWith("sa")).ToList();

            //foreach (Employee emp in employees)
            //{
            //    Console.WriteLine(
            //        $"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F4})");
            //}

            //---------------------------------------------------------------------------//
            //15. Delete Project by Id                                                   //
            //---------------------------------------------------------------------------//
            //var project = content.Projects.Find(2);
            //var employees = content.Employees.ToList();
            //foreach (Employee emp in employees)
            //{
            //    var projects = emp.Projects.ToList();
            //    foreach (Project pr in projects)
            //    {
            //        if (pr.ProjectID == 2) emp.Projects.Remove(pr);
            //    }
            //}
            //content.Projects.Remove(project);
            //content.SaveChanges();
            //var projects10 = content.Projects.Take(10).ToList();
            //foreach (Project pr in projects10)
            //{
            //    Console.WriteLine($"{pr.Name}");
            //}
        }
    }
}
