namespace _3.SalesDatabase
{
    using System;
    using _3.SalesDatabase.Models;
    using System.Data.Entity;
    public class InitializeAndSeed:CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            //context.Sales.Add(new Sale()
            //{
            //    Product = new Product()
            //    {
            //        Name = "Laptop",
            //        Quantity = 10,
            //        Price = 1200
            //    },
            //    Customer = new Customer()
            //    {
            //        Name = "Pesho",
            //        Email = "pesho@peshev.com",
            //        CreditCardNumber = "1233424344449204"
            //    },
            //    StoreLocation = new StoreLocation()
            //    {
            //        LocationName = "Chicago"
            //    },
            //    Date = new DateTime(1993, 07, 25)
            //});
            //context.Sales.Add(new Sale()
            //{
            //    Product = new Product()
            //    {
            //        Name = "Monitor",
            //        Quantity = 15,
            //        Price = 1000
            //    },
            //    Customer = new Customer()
            //    {
            //        Name = "Misho",
            //        Email = "misho@mishanski.com",
            //        CreditCardNumber = "1237933344449204"
            //    },
            //    StoreLocation = new StoreLocation()
            //    {
            //        LocationName = "New York"
            //    },
            //    Date = new DateTime(2001, 09, 12)
            //});
            //context.Sales.Add(new Sale()
            //{
            //    Product = new Product()
            //    {   
            //        Name = "Mouse",
            //        Quantity = 30,
            //        Price = 100
            //    },
            //    Customer = new Customer()
            //    {
            //        Name = "Kiro",
            //        Email = "kiro@kirov.com",
            //        CreditCardNumber = "1233111344449204"
            //    },
            //    StoreLocation = new StoreLocation()
            //    {
            //        LocationName = "LA"
            //    },
            //    Date = new DateTime(2011, 05, 01)
            //});
            //context.Sales.Add(new Sale()
            //{
            //    Product = new Product()
            //    {
            //        Name = "Keyboard",
            //        Quantity = 50,
            //        Price = 50
            //    },
            //    Customer = new Customer()
            //    {
            //        Name = "Ivan",
            //        Email = "ivan@ivanov.com",
            //        CreditCardNumber = "123341556449204"
            //    },
            //    StoreLocation = new StoreLocation()
            //    {
            //        LocationName = "Bankok"
            //    },
            //    Date = new DateTime(2005, 02, 12)
            //});
            //context.Sales.Add(new Sale()
            //{
            //    Product = new Product()
            //    {
            //        Name = "Flash Drive",
            //        Quantity = 100,
            //        Price = 30
            //    },
            //    Customer = new Customer()
            //    {
            //        Name = "Tisho",
            //        Email = "tisho@tishanski.com",
            //        CreditCardNumber = "1233222444449204"
            //    },
            //    StoreLocation = new StoreLocation()
            //    {
            //        LocationName = "Las Vegas"
            //    },
            //    Date = new DateTime(1980, 12, 10)
            //});

            //context.SaveChanges();

            base.Seed(context);
        }
    }
}
