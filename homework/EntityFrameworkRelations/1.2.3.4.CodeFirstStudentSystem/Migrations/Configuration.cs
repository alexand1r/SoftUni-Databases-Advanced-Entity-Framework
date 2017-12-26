using _1.CodeFirstStudentSystem.Models;

namespace _1.CodeFirstStudentSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1.CodeFirstStudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_1.CodeFirstStudentSystem.StudentSystemContext context)
        {
            context.Students.AddOrUpdate(
              p => p.Name,
              new Student { Name = "Pesho", RegistrationDate = DateTime.Now.ToString()},
              new Student { Name = "Tisho", RegistrationDate = DateTime.Now.ToString()},
              new Student { Name = "Misho", RegistrationDate = DateTime.Now.ToString()}
            );

            context.Courses.AddOrUpdate(
              p => p.Name,
              new Course
              {
                  Name = "Geography",
                  StartDate = DateTime.Now.ToString(),
                  EndDate = new DateTime(2017, 2, 2).ToString(),
                  Price = 100M    
              },
              new Course
              {
                  Name = "Math",
                  StartDate = DateTime.Now.ToString(),
                  EndDate = new DateTime(2017, 3, 3).ToString(),
                  Price = 150M
              },
              new Course
              {
                  Name = "Biology",
                  StartDate = DateTime.Now.ToString(),
                  EndDate = new DateTime(2017, 4, 4).ToString(),
                  Price = 200M
              }
            );

            context.Resources.AddOrUpdate(
              p => p.Name,
              new Resource
              {
                  Name = "Cards",
                  Type = TypeOfResource.Document,
                  Url = "www.url1.com",
                  CourseId = 1
              },
              new Resource
              {
                  Name = "Formulas",
                  Type = TypeOfResource.Other,
                  Url = "www.url2.com",
                  CourseId = 2
              },
              new Resource
              {
                  Name = "Organs",
                  Type = TypeOfResource.Video,
                  Url = "www.url3.com",
                  CourseId = 3
              }
            );

            context.Homeworks.AddOrUpdate(
              p => p.Content,
              new Homework
              {
                  Content = "asdasd",
                  Type = TypeOfContent.Application,
                  SubmissionDate = DateTime.Now.ToString(),
                  CourseId = 1,
                  StudentId = 1
              },
              new Homework
              {
                  Content = "zxczxc",
                  Type = TypeOfContent.Pdf,
                  SubmissionDate = DateTime.Now.ToString(),
                  CourseId = 2,
                  StudentId = 2
              },
              new Homework
              {
                  Content = "qweqwe",
                  Type = TypeOfContent.Zip,
                  SubmissionDate = DateTime.Now.ToString(),
                  CourseId = 3,
                  StudentId = 3
              }
            );
           
        }
    }
}
