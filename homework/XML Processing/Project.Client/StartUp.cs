using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Project.Data;

namespace Project.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ShopContext();
            context.Database.Initialize(true);

            //// import jsons - file is located in Client/Import
            //
            //ImportFunctions import = new ImportFunctions();
            //import.ImportUsers(context);
            //import.ImportProducts(context);
            //import.ImportCategories(context);

            //// queries - jsons are located in Client/Export
            //
            //1. products-in-range
            //ProductsInRange(context);

            //2. users-sold-products
            //UsersSoldProducts(context);

            //3. categories-by-products
            //CategoriesByProducts(context);

            //4. users-and-products
            //UsersAndProducts(context);
        }

        private static void UsersAndProducts(ShopContext context)
        {
            var usersAndProducts = context.Users
                            .Where(u => u.SelledProducts.Count >= 1)
                            .Select(u => new
                            {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                SoldProductsCount = u.SelledProducts.Count(),
                                SoldProducts = new
                                {
                                    Count = u.SelledProducts.Count,
                                    Products = u.SelledProducts.Select(p => new
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                }
                            });

            string json = JsonConvert.SerializeObject(
                new { UsersCount = usersAndProducts.Count(), Users = usersAndProducts }, Formatting.Indented);
            File.WriteAllText("../../Export/users-and-products.json", json);
        }

        private static void CategoriesByProducts(ShopContext context)
        {
            var categoriesByProducts = context.Categories
                            .Select(c => new
                            {
                                Category = c.Name,
                                ProductsCount = c.Products.Count,
                                AveragePrice = c.Products.Sum(p => p.Price) / c.Products.Count,
                                TotalRevenue = c.Products.Sum(p => p.Price)
                            });

            string json = JsonConvert.SerializeObject(categoriesByProducts, Formatting.Indented);
            File.WriteAllText("../../Export/categories-by-products.json", json);
        }

        private static void UsersSoldProducts(ShopContext context)
        {
            var usersSoldProducts = context.Users
                            .Where(u => u.SelledProducts.Count > 0)
                            .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
                            .Select(u => new
                            {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                SoldProducts = u.SelledProducts
                                    .Where(sp => sp.Buyer != null)
                                    .Select(p => new
                                    {
                                        Name = p.Name,
                                        Price = p.Price,
                                        BuyerFirstName = p.Buyer.FirstName,
                                        BuyerLastName = p.Buyer.LastName
                                    })
                            });

            string json = JsonConvert.SerializeObject(usersSoldProducts, Formatting.Indented);
            File.WriteAllText("../../Export/users-sold-products.json", json);
        }

        private static void ProductsInRange(ShopContext context)
        {
            var products = context.Products
                            .Where(p => p.Price >= 500 && p.Price <= 1000)
                            .OrderBy(p => p.Price)
                            .Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price,
                                SellerName = p.Seller.FirstName ?? "" + " " + p.Seller.LastName
                            });

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("../../Export/products-in-range.json", json);
        }
    }
}
