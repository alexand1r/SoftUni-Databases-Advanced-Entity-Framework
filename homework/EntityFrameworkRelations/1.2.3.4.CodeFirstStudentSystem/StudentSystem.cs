using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using _1.CodeFirstStudentSystem.Models;

namespace _1.CodeFirstStudentSystem
{
    class StudentSystem
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.Initialize(true);

        //////PRINT ALL STUDENTS WITH THEIR HOMEWORK SUBMISSIONS
            //----------------------------------------------------
            //var students = context.Students;
            //foreach (Student st in students)
            //{
            //    Console.WriteLine(st.Name);
            //    foreach (Homework homework in st.Homeworks)
            //    {
            //        Console.WriteLine(homework.Content + " - " + homework.Type);
            //    }
            //}

        //////PRINT ALL COURSES WITH THEIR RESOURCES
            //----------------------------------------
            //var courses = context.Courses;
            //foreach (Course course in courses
            //    .OrderBy(c => c.StartDate)
            //    .ThenByDescending(c => c.EndDate))
            //{
            //    Console.WriteLine(course.Name + " - " + course.Description);
            //    foreach (Resource resource in course.Resources)
            //    {
            //        Console.WriteLine(resource.Name + " - " + resource.Type + " - " + resource.Url);
            //    }
            //}

        //////PRINT ALL COURSES WITH MORE THAN 5 RESOURCES
            //----------------------------------------------
            //var courses =
            //    context.Courses.Where(c => c.Resources.Count > 5)
            //        .OrderByDescending(c => c.Resources.Count)
            //        .ThenByDescending(c => c.StartDate)
            //        .ToList();
            //foreach (Course course in courses)
            //{
            //    Console.WriteLine(course.Name + " - " + course.Resources.Count + " resources");
            //}

        //////LIST ALL COURSES WHICH WERE ACTIVE ON A GIVEN DATE
            //----------------------------------------------------
            //DateTime date = new DateTime(2017, 9, 3);
            //var courses = context.Courses
            //    .Where(c => c.StartDate <= date
            //                && c.EndDate > date)
            //    .OrderByDescending(c => c.Students.Count)
            //    .ThenByDescending(c => c.EndDate - c.StartDate)
            //    .ToList();
            //foreach (Course course in courses)
            //{
            //    Console.WriteLine(course.Name + " - " + course.StartDate + " - " + course.EndDate + " - " + (course.EndDate - course.StartDate));
            //}

        //////STUDENT INFO FOR COURSES AND PRICES
            //-------------------------------------
            //var students = context.Students
            //    .OrderByDescending(s => s.Courses.Sum(c => c.Price))
            //    .ThenByDescending(s => s.Courses.Count)
            //    .ThenBy(s => s.Name)
            //    .ToList();
            //foreach (Student st in students)
            //{
            //    Console.WriteLine(st.Name + " - " + st.Courses.Count + " courses");
            //    var total = 0M;
            //    foreach (Course course in st.Courses)
            //    {
            //        total += course.Price;
            //    }
            //    Console.WriteLine(total + " - " + total / st.Courses.Count);
            //}
        }
    }
}
