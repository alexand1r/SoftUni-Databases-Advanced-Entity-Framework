using Photographers.Models;

namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.PhotographersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Photographers.PhotographersContext context)
        {
            context.Photographers.AddOrUpdate(
              p => p.Username,
              new Photographer
              {
                  Username = "Andrew Peters",
                  Password = "qweqwe",
                  Email = "qwe@qwe.com",
                  RegisterDate = DateTime.Now,
                  BirthDate = DateTime.Now
              },
              new Photographer
              {
                  Username = "Brice Lambson",
                  Password = "asdasd",
                  Email = "asd@asd.com",
                  RegisterDate = DateTime.Now,
                  BirthDate = DateTime.Now
              },
              new Photographer
              {
                  Username = "Rowan Miller",
                  Password = "zxczxc",
                  Email = "zxc@zxc.com",
                  RegisterDate = DateTime.Now,
                  BirthDate = DateTime.Now
              }
            );

            context.Pictures.AddOrUpdate(
              p => p.Title,
              new Picture
              {
                  Title = "Old",
                  Caption = "qweqwe",
                  Path = "c://qweqwe",
              },
              new Picture
              {
                  Title = "New",
                  Caption = "asdasd",
                  Path = "c://asdasd",
              },
              new Picture
              {
                  Title = "Present",
                  Caption = "zxczxc",
                  Path = "c://zxczxc",
              }
            );

            context.Albums.AddOrUpdate(
              a => a.BackgroundColor,
              new Album
              {
                  BackgroundColor = "Red",
                  IsPublic = false,
                  PhotographerId = 1,
              },
              new Album
              {
                  BackgroundColor = "Green",
                  IsPublic = true,
                  PhotographerId = 2,
              },
              new Album
              {
                  BackgroundColor = "Blue",
                  IsPublic = true,
                  PhotographerId = 3,
              }
            );

            context.Tags.AddOrUpdate(
              t => t.Name,
              new Tag
              {
                  Name = "Red"
              },
              new Tag
              {
                  Name = "Green"
              },
              new Tag
              {
                  Name = "Blue"
              }
            );
        }
    }
}
