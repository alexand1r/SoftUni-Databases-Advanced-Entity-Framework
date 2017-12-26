using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using CarDealer.Data;
using System.Linq;
using System.Security.Cryptography;
using CarDealer.Models;
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

        }
    }
}
