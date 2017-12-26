using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase
{
    class GringottsDatabase
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();

            //// 19. Deposits Sum for Ollivander Family
            //DepositsSumForOllivanderFamily(context);

            //// 20. Deposits Filter
            //DepositsFilter(context);
        }

        private static void DepositsFilter(GringottsContext context)
        {
            Dictionary<string, decimal> depositGroupsWithTotalAmount = new Dictionary<string, decimal>();
            var depositGroups = context.WizzardDeposits
                            .Where(w => w.MagicWandCreator == "Ollivander family")
                            .Distinct()
                            .ToList();

            foreach (WizzardDeposit wd in depositGroups)
            {
                decimal sum = context
                    .Database.SqlQuery<decimal>(@"SELECT SUM(DepositAmount) 
                                                  FROM dbo.WizzardDeposits 
                                                  WHERE DepositGroup = {0}
                                                  AND MagicWandCreator = {1}"
                                                , wd.DepositGroup, "Ollivander family").First();
                if (!depositGroupsWithTotalAmount.ContainsKey(wd.DepositGroup))
                {
                    depositGroupsWithTotalAmount.Add(wd.DepositGroup, sum);
                }
            }
            var depositGroupsList =
                depositGroupsWithTotalAmount
                .Where(d => d.Value < 150000)
                .OrderByDescending(d => d.Value).ToList();
            foreach (var item in depositGroupsList)
            {
                Console.WriteLine($"{item.Key} - {item.Value:F2}");
            }
        }

        private static void DepositsSumForOllivanderFamily(GringottsContext context)
        {
            var depositGroups = context.WizzardDeposits
                            .Where(w => w.MagicWandCreator == "Ollivander family")
                            .Distinct()
                            .ToList();

            foreach (WizzardDeposit wd in depositGroups)
            {
                decimal sum = context
                    .Database.SqlQuery<decimal>(@"SELECT SUM(DepositAmount) 
                                                  FROM dbo.WizzardDeposits 
                                                  WHERE DepositGroup = {0}
                                                  AND MagicWandCreator = {1}"
                                                , wd.DepositGroup, "Ollivander family").First();
                Console.WriteLine($"{wd.DepositGroup} - {sum:F2}");
            }
        }
    }
}
