using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using CarDealer.Data;
using System.Linq;
using System.Security.Cryptography;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Numerics;

namespace CarDealer.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.Initialize(true);

            //// import jsons - file is located in Client/Import
            //
            //ImportFunctions import = new ImportFunctions();
            //import.ImportSuppliers(context);
            //import.ImportParts(context);
            //import.ImportCars(context);
            //import.ImportCustomers(context);
            //import.ImportSales(context);

            //// queries - jsons are located in Client/Export
            //
            //1. ordered-customers
            //OrderedCustomers(context);

            //2. toyota-cars
            //ToyotaCars(context);

            //3. local-suppliers
            //LocalSuppliers(context);

            //4. cars-and-parts
            //CarsAndParts(context);

            //5. customers-total-sales
            //CustomersTotalSales(context);

            //6. sales-discounts
            var salesDiscounts = context.Sales
                .Select(s => new
                {
                    Car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount / 100,
                    Price = s.Car.Parts.Sum(p => p.Price),
                    PriceWithDiscount = (s.Discount / 100) * s.Car.Parts.Sum(p => p.Price)
                });

            string json = JsonConvert.SerializeObject(salesDiscounts, Formatting.Indented);
            File.WriteAllText("../../Export/sales-discounts.json", json);
        }

        private static void CustomersTotalSales(CarDealerContext context)
        {
            var customerTotalSales = context.Customers
                            .Where(c => c.Sales.Count >= 1)
                            .OrderByDescending(c => c.Sales.Sum(s => (s.Discount / 100) * s.Car.Parts.Sum(p => p.Price)))
                            .ThenByDescending(c => c.Sales.Count)
                            .Select(c => new
                            {
                                FullName = c.Name,
                                BoughtCars = c.Sales.Count,
                                SpentMoney = c.Sales.Sum(s => (s.Discount / 100) * s.Car.Parts.Sum(p => p.Price))
                            });

            string json = JsonConvert.SerializeObject(customerTotalSales, Formatting.Indented);
            File.WriteAllText("../../Export/customer-total-sales.json", json);
        }

        private static void CarsAndParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars.Select(c => new
            {
                Car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                },
                Parts = c.Parts.Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price
                })
            });

            string json = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
            File.WriteAllText("../../Export/cars-and-parts.json", json);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                            .Where(s => s.IsImporter == false)
                            .Select(s => new
                            {
                                Id = s.Id,
                                Name = s.Name,
                                PartsCount = s.Parts.Count
                            });

            string json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            File.WriteAllText("../../Export/local-suppliers.json", json);
        }

        private static void ToyotaCars(CarDealerContext context)
        {
            var toyotaCars =
                                        context.Cars
                                        .Where(c => c.Make == "Toyota")
                                        .OrderBy(c => c.Model)
                                        .ThenByDescending(c => c.TravelledDistance)
                                        .Select(c => new
                                        {
                                            Id = c.Id,
                                            Make = c.Make,
                                            Model = c.Model,
                                            TravelledDistance = c.TravelledDistance
                                        });

            string json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            File.WriteAllText("../../Export/toyota-cars.json", json);
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers =
                            context.Customers
                            .OrderBy(c => c.DateOfBirth)
                            .ThenBy(c => c.IsYoungDriver)
                            .Select(c => new
                            {
                                Id = c.Id,
                                Name = c.Name,
                                DateOfBirth = c.DateOfBirth,
                                IsYoungDriver = c.IsYoungDriver,
                                Sales = "[]"
                            });

            string json = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
            File.WriteAllText("../../Export/ordered-customers.json", json);
        }
    }
}
