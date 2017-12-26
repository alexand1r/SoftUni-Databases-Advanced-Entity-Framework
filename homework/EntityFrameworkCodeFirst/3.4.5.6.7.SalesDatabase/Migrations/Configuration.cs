using _3.SalesDatabase.Models;

namespace _3.SalesDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() { Name = "PS4", Desription = "Console"});
            context.Products.AddOrUpdate(new Product() { Name = "Xbox1", Desription = "Console"});
            context.Products.AddOrUpdate(new Product() { Name = "PC", Desription = "Computer"});

            context.Customers.AddOrUpdate(new Customer() { FirstName = "Pesho", LastName = "Peshanski"});
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Tisho", LastName = "Tishanski"});
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Misho", LastName = "Mishanski"});
        }
    }
}
