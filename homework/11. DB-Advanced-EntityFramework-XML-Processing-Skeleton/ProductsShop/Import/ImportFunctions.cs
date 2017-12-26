using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProductsShop.Data;
using ProductsShop.Model;

namespace ProductsShop.Import
{
    public class ImportFunctions
    {
        public void ImportCategories(ProductShopContext context)
        {
            XDocument categoriesDoc = XDocument.Load("../../Import/categories.xml");

            XElement categoriesRoot = categoriesDoc.Root;

            int number = 0;
            int productsCount = context.Products.Count();
            foreach (XElement categoryElement in categoriesRoot.Elements())
            {
                string name = categoryElement.Element("name").Value;

                Category category = new Category()
                {
                    Name = name
                };
                for (int i = 0; i < productsCount; i++)
                {
                    category.Products.Add(context.Products.Find((number % productsCount) + 1));
                }
                number++;

                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        public void ImportProducts(ProductShopContext context)
        {
            XDocument productsDoc = XDocument.Load("../../Import/products.xml");

            XElement productsRoot = productsDoc.Root;

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (XElement productElement in productsRoot.Elements())
            {
                string name = productElement.Element("name").Value;
                decimal price = decimal.Parse(productElement.Element("price").Value);

                Product product = new Product()
                {
                    Name = name,
                    Price = price,
                };
                product.SelledId = (number % usersCount) + 1;
                if (number % 3 != 0)
                {
                    product.BuyerId = (number * 2 % usersCount) + 1;
                }
                number++;

                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        public void ImportUsers(ProductShopContext context)
        {
            XDocument usersDoc = XDocument.Load("../../Import/users.xml");

            XElement usersRoot = usersDoc.Root;

            foreach (XElement userElement in usersRoot.Elements())
            {
                string firstName = userElement.Attribute("first-name")?.Value;
                string lastName = userElement.Attribute("last-name")?.Value;
                int age = Convert.ToInt32(userElement.Attribute("age")?.Value);

                User user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
