using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniDatabase.ViewModel;

namespace SoftUniDatabase
{
    class SoftUniDatabase
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            //// 17. Call a Stored Procedure
            //CallAStoredProcedure(context);

            //// 18. Employees Maximum Salaries
            //EmployeesMaximumSalaries(context);
        }

        private static void EmployeesMaximumSalaries(SoftUniContext context)
        {
            var departments = context.Departments.Where(d => d.Employees.Max(e => e.Salary) < 30000
                                                                         || d.Employees.Max(e => e.Salary) > 70000).ToList();
            foreach (Department d in departments)
            {
                Console.WriteLine($"{d.Name} - {d.Employees.Max(e => e.Salary):F2}");
            }
        }

        private static void CallAStoredProcedure(SoftUniContext context)
        {
            string[] data = Console.ReadLine().Split(' ');
            var projects = context.Database
                .SqlQuery<ProjectViewModel>("EXEC dbo.udp_FindProjectsByEmployeeName {0}, {1}", data[0], data[1]);
            foreach (ProjectViewModel p in projects)
            {
                Console.WriteLine($"{p.Name} - {p.Description}, {p.StartDate}");
            }
        }
    }
}
