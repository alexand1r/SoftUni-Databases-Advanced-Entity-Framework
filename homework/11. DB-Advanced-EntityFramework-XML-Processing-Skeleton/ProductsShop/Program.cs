using System;
using System.Diagnostics.Eventing.Reader;
using ProductsShop.Import;
using System.Data.Entity;

namespace ProductsShop
{
    using System.Linq;
    using System.Xml.Linq;

    using Data;

    using Model;

    public class Application
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.Initialize(true);

            //// file located in Import folder
            //ImportFunctions import = new ImportFunctions();
            //import.ImportUsers(context);
            //import.ImportProducts(context);
            //import.ImportCategories(context);

            //// files located in Export folder
            //Query 1. products-in-range.xml
            //ProductsInRange(context);

            //Query 2. users-sold-products.xml
            //UsersSoldProducts(context);

            //Query 3. categories-by-products.xml
            //CategoriesByProducts(context);

            //Query 4. users-and-products.xml
            //UsersAndProducts(context);
        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var usersAndProducts = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold.Select(ps => new
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                });

            XDocument usersAndProductsDoc = new XDocument();

            XElement users = new XElement("users");
            users.SetAttributeValue("count", context.Users.Count());

            foreach (var up in usersAndProducts)
            {
                XElement user = new XElement("user");
                user.SetAttributeValue("first-name", up.FirstName);
                user.SetAttributeValue("last-name", up.LastName);
                user.SetAttributeValue("age", up.Age);

                XElement soldProducts = new XElement("sold-prducts");
                soldProducts.SetAttributeValue("count", up.SoldProducts.Count());

                foreach (var sp in up.SoldProducts)
                {
                    XElement product = new XElement("product");
                    product.SetAttributeValue("name", sp.Name);
                    product.SetAttributeValue("price", sp.Price);

                    soldProducts.Add(product);
                }

                user.Add(soldProducts);
                users.Add(user);
            }

            usersAndProductsDoc.Add(users);
            usersAndProductsDoc.Save("../../Export/users-and-products.xml");
        }

        private static void CategoriesByProducts(ProductShopContext context)
        {
            var categoriesByProducts = context.Categories
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    Name = c.Name,
                    ProductsCount = c.Products.Count,
                    AveragePrice = c.Products.Average(p => p.Price),
                    TotalRevenue = c.Products.Sum(p => p.Price)
                });

            XDocument categoriesByProductsDoc = new XDocument();

            XElement categories = new XElement("categories");

            foreach (var cbp in categoriesByProducts)
            {
                XElement category = new XElement("category");
                category.SetAttributeValue("name", cbp.Name);

                XElement productsCount = new XElement("products-count");
                productsCount.Value = cbp.ProductsCount.ToString();
                XElement averagePrice = new XElement("average-price");
                averagePrice.Value = cbp.AveragePrice.ToString();
                XElement totalRevenue = new XElement("total-revenue");
                totalRevenue.Value = cbp.TotalRevenue.ToString();

                category.Add(productsCount);
                category.Add(averagePrice);
                category.Add(totalRevenue);

                categories.Add(category);
            }

            categoriesByProductsDoc.Add(categories);
            categoriesByProductsDoc.Save("../../Export/categories-by-products.xml");
        }

        private static void UsersSoldProducts(ProductShopContext context)
        {
            var usersSoldProducts = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price
                    }),
                });

            XDocument usersSoldProductsDoc = new XDocument();
            XElement usersXml = new XElement("users");

            foreach (var usp in usersSoldProducts)
            {
                XElement user = new XElement("user");
                user.SetAttributeValue("first-name", usp.FirstName);
                user.SetAttributeValue("last-name", usp.LastName);

                XElement soldProducts = new XElement("sold-products");
                foreach (var sp in usp.SoldProducts)
                {
                    XElement product = new XElement("product");
                    
                    XElement name = new XElement("name");
                    name.Value = sp.Name;
                    XElement price = new XElement("price");
                    price.Value = sp.Price.ToString();

                    product.Add(name);
                    product.Add(price);

                    soldProducts.Add(product);
                }

                user.Add(soldProducts);
                usersXml.Add(user);
            }

            usersSoldProductsDoc.Add(usersXml);
            usersSoldProductsDoc.Save("../../Export/users-sold-products.xml");
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Include(p => p.Buyer)
                .Where(p => p.Price >= 1000 && p.Price <= 2000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                });

            XDocument productsInRangeDoc = new XDocument();
            XElement products = new XElement("products");

            foreach (var pir in productsInRange)
            {
                XElement product = new XElement("product");
                product.SetAttributeValue("name", pir.Name);
                product.SetAttributeValue("price", pir.Price);
                product.SetAttributeValue("buyer", pir.Buyer);

                products.Add(product);
            }

            productsInRangeDoc.Add(products);
            productsInRangeDoc.Save("../../Export/products-in-range.xml");
        }
    }
}
