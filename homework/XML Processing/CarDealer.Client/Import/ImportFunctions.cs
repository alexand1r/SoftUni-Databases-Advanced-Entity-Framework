using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.Client.Import
{
    public class ImportFunctions
    {
        public void ImportSales(CarDealerContext context)
        {
            Random r1 = new Random();
            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();
            for (int i = 0; i < 50; i++)
            {
                Sale newSale = new Sale
                {
                    Car = context.Cars.Find(r1.Next(1, carsCount)),
                    Customer = context.Customers.Find(r1.Next(1, customersCount)),
                    Discount = (decimal)r1.Next(0, 50)
                };
                context.Sales.Add(newSale);
            }
            context.SaveChanges();
        }

        public void ImportCustomers(CarDealerContext context)
        {
            string customersJson = File.ReadAllText("../../Import/customers.json");

            List<Customer> customers =
                JsonConvert.DeserializeObject<List<Customer>>(customersJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        public void ImportCars(CarDealerContext context)
        {
            string carsJson = File.ReadAllText("../../Import/cars.json");

            List<Car> cars =
                JsonConvert.DeserializeObject<List<Car>>(carsJson);

            Random r1 = new Random();
            int partsCount = context.Parts.Count();
            foreach (Car c in cars)
            {
                int randomNumber = r1.Next(10, 20);
                for (int i = 0; i < randomNumber; i++)
                {
                    c.Parts.Add(context.Parts.Find(r1.Next(1, partsCount)));
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        public void ImportParts(CarDealerContext context)
        {
            string partsJson = File.ReadAllText("../../Import/parts.json");

            List<Part> parts =
                JsonConvert.DeserializeObject<List<Part>>(partsJson);

            int number = 0;
            int suppliersCount = context.Suppliers.Count();
            foreach (Part p in parts)
            {
                p.SupplierId = (number % suppliersCount) + 1;
                number++;
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        public void ImportSuppliers(CarDealerContext context)
        {
            string suppliersJson = File.ReadAllText("../../Import/suppliers.json");

            List<Supplier> suppliers =
                JsonConvert.DeserializeObject<List<Supplier>>(suppliersJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }
    }
}
