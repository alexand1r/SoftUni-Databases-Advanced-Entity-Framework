using Project.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Client.Import
{
    public class ImportFunctions
    {
        public void ImportCategories(ShopContext context)
        {
            string categoriesJson = File.ReadAllText(@"../../Import/categories.json");

            List<Category> categories =
                JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            int number = 0;
            int productCount = context.Products.Count();
            foreach (Category c in categories)
            {
                int productsCount = number % productCount;
                for (int i = 0; i < productsCount; i++)
                {
                    c.Products.Add(context.Products.Find((number % productCount) + 1));
                }

                number++;
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public void ImportProducts(ShopContext context)
        {
            string productsJson = File.ReadAllText(@"../../Import/products.json");

            List<Product> products =
                JsonConvert.DeserializeObject<List<Product>>(productsJson);

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (Product p in products)
            {
                p.SellerId = (number % usersCount) + 1;
                if (number % 3 != 0)
                {
                    p.BuyerId = (number * 2 % usersCount) + 1;
                }
                number++;
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public void ImportUsers(ShopContext context)
        {
            string usersJson = File.ReadAllText(@"../../Import/users.json");

            List<User> users =
                JsonConvert.DeserializeObject<List<User>>(usersJson);

            context.Users.AddRange(users);
            context.SaveChanges();
        }

    }
}
