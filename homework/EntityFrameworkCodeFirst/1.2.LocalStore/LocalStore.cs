namespace _1.LocalStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class LocalStore
    {
        static void Main(string[] args)
        {
            var context = new ProductContext();
            context.Database.Initialize(true);

            context.Products.Add(new Product()
            {
                Name = "Laptop",
                DistributorName = "Lenovo",
                Description = "very good condition",
                Price = 1199.99M,
                Weight = 1.5M,
                Quantity = 10
            });

            context.Products.Add(new Product()
            {
                Name = "Monitor",
                DistributorName = "Philips",
                Description = "nice quality",
                Price = 1199.99M,
                Weight = 2M,
                Quantity = 5
            });

            context.Products.Add(new Product()
            {
                Name = "Google Nexus 4",
                DistributorName = "Google",
                Description = "android 7.0",
                Price = 299.99M,
                Weight = 0.1M,
                Quantity = 15
            });

            context.SaveChanges();
        }
    }
}
