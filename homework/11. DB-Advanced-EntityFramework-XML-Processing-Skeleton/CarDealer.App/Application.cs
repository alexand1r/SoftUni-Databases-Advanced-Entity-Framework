using System.Linq;
using System.Xml.Linq;
using CarDealer.App.Import;
using System.Data.Entity;

namespace CarDealer.App
{
    using System;

    using Data;
    using Models;

    public class Application
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.Initialize(true);

            //// file located in Import folder 
            //ImportFunctions import = new ImportFunctions();
            //import.ImportSuppliers(context);
            //import.ImportParts(context);
            //import.ImportCars(context);
            //import.ImportCustomers(context);
            //import.ImportSales(context);

            //// files located in Export folder
            //Query 1. cars.xml
            //Cars(context);

            //Query 2. ferrari-cars.xml
            //FerrariCars(context);

            //Query 3. local-suppliers.xml
            //LocalSuppliers(context);

            //Query 4. cars-and-parts.xml
            //CarsAndParts(context);

            //Query 5. customers-total-sales.xml
            //CustomersTotalSales(context);

            //Query 6. sales-discounts.xml
            //SalesDiscounts(context);

        }

        private static void CustomersTotalSales(CarDealerContext context)
        {
            var customersTotalSales = context.Customers.Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                }).OrderByDescending(c => c.BoughtCars).ThenBy(c => c.SpentMoney).ToList();

            var customersTotalSalesXml = new XElement("customers", customersTotalSales
                .Select(c =>
                    new XElement("customer",
                        new XAttribute("full-name", c.FullName),
                        new XAttribute("bought-cars", c.BoughtCars),
                        new XAttribute("spent-money", c.SpentMoney))));
            XDocument doc = new XDocument();
            doc.Add(customersTotalSalesXml);
            doc.Save("../../Export/customers-total-sales.xml");
        }

        private static void CarsAndParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Include(c => c.Parts)
                .Select(c => new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts
                });

            XDocument carsAndPartsDocument = new XDocument();
            XElement carsXml = new XElement("cars");

            foreach (var c in carsAndParts)
            {
                XElement car = new XElement("car");
                car.SetAttributeValue("make", c.Make);
                car.SetAttributeValue("model", c.Model);
                car.SetAttributeValue("travelled-distance", c.TravelledDistance);
                
                XElement partsXml = new XElement("parts");
                foreach (var p in c.Parts)
                {
                    XElement part = new XElement("part");
                    part.SetAttributeValue("name", p.Name);
                    part.SetAttributeValue("price", p.Price);

                    partsXml.Add(part);
                }

                car.Add(partsXml);

                carsXml.Add(car);
            }

            carsAndPartsDocument.Add(carsXml);
            carsAndPartsDocument.Save("../../Export/cars-and-parts.xml");
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Include(s => s.Parts)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                });

            XDocument localSuppliersDocument = new XDocument();
            XElement suppliersXml = new XElement("suppliers");

            foreach (var s in localSuppliers)
            {
                XElement supplier = new XElement("supplier");

                supplier.SetAttributeValue("id", s.Id);
                supplier.SetAttributeValue("name", s.Name);
                supplier.SetAttributeValue("parts-count", s.PartsCount);

                suppliersXml.Add(supplier);
            }

            localSuppliersDocument.Add(suppliersXml);
            localSuppliersDocument.Save("../../Export/local-suppliers.xml");
        }

        private static void FerrariCars(CarDealerContext context)
        {
            var ferrariCars = context.Cars
                   .Where(c => c.Make == "Ferrari")
                   .Select(c => new
                   {
                       Id = c.Id,
                       Model = c.Model,
                       TravelledDistance = c.TravelledDistance
                   });

            XDocument ferrariCarsDocument = new XDocument();
            XElement carsXml = new XElement("cars");

            foreach (var fc in ferrariCars)
            {
                XElement car = new XElement("car");

                car.SetAttributeValue("id", fc.Id);
                car.SetAttributeValue("Model", fc.Model);
                car.SetAttributeValue("travelled-distance", fc.TravelledDistance);

                carsXml.Add(car);
            }

            ferrariCarsDocument.Add(carsXml);
            ferrariCarsDocument.Save("../../Export/ferrari-cars.xml");
        }

        private static void Cars(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                });

            XDocument carsDocument = new XDocument();
            XElement carsXml = new XElement("cars");

            foreach (var c in cars)
            {
                XElement car = new XElement("car");

                XElement make = new XElement("make");
                make.Value = c.Make;
                XElement model = new XElement("model");
                model.Value = c.Model;
                XElement travelledDistance = new XElement("travelled-distance");
                travelledDistance.Value = c.TravelledDistance.ToString();

                car.Add(make);
                car.Add(model);
                car.Add(travelledDistance);

                carsXml.Add(car);
            }

            carsDocument.Add(carsXml);
            carsDocument.Save("../../Export/cars.xml");
        }

        private static void SalesDiscounts(CarDealerContext context)
        {
            var sales = context.Sales
                .Include(s => s.Car)
                .Include(s => s.Customer)
                .Include(s => s.Car.Parts)
                .Select(s => new
                {
                    Car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Price),
                    PriceWithDiscount = (s.Car.Parts.Sum(p => p.Price) * (1.0M - s.Discount))
                });

            XDocument salesDocument = new XDocument();
            XElement salesXml = new XElement("sales");

            foreach (var sale in sales)
            {
                XElement saleXml = new XElement("sale");
                XElement car = new XElement("car");
                car.SetAttributeValue("make", sale.Car.Make);
                car.SetAttributeValue("model", sale.Car.Model);
                car.SetAttributeValue("distance-travelled", sale.Car.TravelledDistance);
                XElement customer = new XElement("customer-name");
                customer.Value = sale.CustomerName;

                XElement discount = new XElement("discount");
                discount.Value = sale.Discount.ToString();

                XElement price = new XElement("price");
                price.Value = sale.Price.ToString();

                XElement priceWithDiscount = new XElement("price-with-discount");
                priceWithDiscount.Value = sale.PriceWithDiscount.ToString();

                saleXml.Add(car);
                saleXml.Add(customer);
                saleXml.Add(discount);
                saleXml.Add(price);
                saleXml.Add(priceWithDiscount);

                salesXml.Add(saleXml);
            }

            salesDocument.Add(salesXml);

            salesDocument.Save("../../Export/sales-discounts.xml");
        }
    }
}
