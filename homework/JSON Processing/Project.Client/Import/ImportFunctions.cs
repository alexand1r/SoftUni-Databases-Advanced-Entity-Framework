using Project.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Project.Models;

namespace Project.Client.Import
{
    public class ImportFunctions
    {
        public void ImportCategories(ShopContext context)
        {
            XDocument categoriesXml = XDocument.Load(@"../../Import/categories.xml");

            XElement productsRoot = categoriesXml.Root;

            int number = 0;
            int productCount = context.Products.Count();
            foreach (XElement categoryElement in productsRoot.Elements())
            {
                string name = categoryElement.Attribute("name")?.Value;

                int productsCount = number % productCount;

                Category category = new Category
                {
                    Name = name
                };

                for (int i = 0; i < productsCount; i++)
                {
                    category.Products.Add(context.Products.Find((number % productCount) + 1));
                }

                number++;

                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        public void ImportProducts(ShopContext context)
        {
            XDocument productsXml = XDocument.Load(@"../../Import/products.xml");

            XElement productsRoot = productsXml.Root;

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (XElement productElement in productsRoot.Elements())
            {
                string name = productElement.Attribute("name")?.Value;
                decimal price = decimal.Parse(productElement.Attribute("price")?.Value);

                Product product = new Product
                {
                    Name = name,
                    Price = price
                };
                product.SellerId = (number % usersCount) + 1;
                if (number % 3 != 0)
                {
                    product.BuyerId = (number * 2 % usersCount) + 1;
                }
                number++;

                context.Products.Add(product);
            } 

            context.SaveChanges();
        }

        public void ImportUsers(ShopContext context)
        {
            XDocument usersXml = XDocument.Load(@"../../Import/users.xml");

            XElement usersRoot = usersXml.Root;

            foreach (XElement userElement in usersRoot.Elements())
            {
                string firstName = userElement.Attribute("first-name")?.Value;
                string lastName = userElement.Attribute("last-name")?.Value;
                int age = int.Parse(userElement.Attribute("age")?.Value);

                User user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age != null ? age : 0
                };

                context.Users.Add(user);
            }
            
            context.SaveChanges();
        }

    }
}
