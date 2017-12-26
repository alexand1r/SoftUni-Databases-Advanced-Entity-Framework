using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealer.App.Import
{
    public class ImportFunctions
    {
        public void ImportSales(CarDealerContext context)
        {
            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Sale sale = new Sale()
                {
                    CarId = rnd.Next(1, carsCount + 1),
                    CustomerId = rnd.Next(1, customersCount + 1),
                    Discount = i % 2 == 0 ? 0.05M : 0.00M
                };

                context.Sales.Add(sale);
            }

            context.SaveChanges();
        }

        public void ImportCustomers(CarDealerContext context)
        {
            XDocument customersDoc = XDocument.Load("../../Import/customers.xml");

            XElement customersRoot = customersDoc.Root;

            foreach (XElement customerElement in customersRoot.Elements())
            {
                string name = customerElement.Attribute("name").Value;
                DateTime dateTime = DateTime.Parse(customerElement.Element("birth-date").Value);
                bool isYoungDriver = bool.Parse(customerElement.Element("is-young-driver").Value);

                Customer customer = new Customer()
                {
                    Name = name,
                    BirthDate = dateTime,
                    IsYoungDriver = isYoungDriver
                };

                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }

        public void ImportCars(CarDealerContext context)
        {
            XDocument carsDoc = XDocument.Load("../../Import/cars.xml");

            XElement carsRoot = carsDoc.Root;

            foreach (XElement carElement in carsRoot.Elements())
            {
                string make = carElement.Element("make").Value;
                string model = carElement.Element("model").Value;
                long travelledDistance = long.Parse(carElement.Element("travelled-distance").Value);

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = travelledDistance
                };

                int partsCount = context.Parts.Count();
                for (int i = 0; i < 10 + (i % 10); i++)
                {
                    Part p = context.Parts.Find((carElement.GetHashCode() % partsCount) + 1);
                    car.Parts.Add(p);
                }

                context.Cars.Add(car);
            }

            context.SaveChanges();
        }

        public void ImportParts(CarDealerContext context)
        {
            XDocument partsDoc = XDocument.Load("../../Import/parts.xml");

            XElement partsRoot = partsDoc.Root;

            int number = 0;
            int suppliersCount = context.Suppliers.Count();
            foreach (XElement partElement in partsRoot.Elements())
            {
                string name = partElement.Attribute("name").Value;
                decimal price = decimal.Parse(partElement.Attribute("price").Value);
                int quantity = int.Parse(partElement.Attribute("quantity").Value);

                Part part = new Part()
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    SupplierId = (number % suppliersCount) + 1
                };

                context.Parts.Add(part);
                number++;
            }

            context.SaveChanges();
        }

        public void ImportSuppliers(CarDealerContext context)
        {
            XDocument suppliersDoc = XDocument.Load("../../Import/suppliers.xml");

            XElement suppliersRoot = suppliersDoc.Root;

            foreach (XElement supplierElement in suppliersRoot.Elements())
            {
                string name = supplierElement.Attribute("name")?.Value;
                bool isImporter = bool.Parse(supplierElement.Attribute("is-importer").Value);

                Supplier sup = new Supplier()
                {
                    Name = name,
                    IsImporter = isImporter
                };

                context.Suppliers.Add(sup);
            }

            context.SaveChanges();
        }
    }
}
