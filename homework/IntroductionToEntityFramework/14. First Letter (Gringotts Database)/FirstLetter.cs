using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.First_Letter__Gringotts_Database_
{
    class FirstLetter
    {
        static void Main(string[] args)
        {
            GringottsContext context = new GringottsContext();

            var wizards = context.WizzardDeposits
                .Where(w => w.DepositGroup == "Troll Chest")
                .Select(w => w.FirstName)
                .ToList()
                .Select(fn => fn[0])
                .Distinct()
                .OrderBy(c => c);

            foreach (char wiz in wizards)
            {
                Console.WriteLine(wiz);
            }
        }
    }
}
