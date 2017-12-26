namespace _7.GringottsDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class GringottsDatabase
    {
        static void Main(string[] args)
        {
            WizardDeposits dumbledore = new WizardDeposits()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Paverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false,
            };

            var context = new GringottsContext();
            //context.Database.Initialize(true);
            context.WizardDepositses.Add(dumbledore);
            context.SaveChanges();
        }
    }
}
