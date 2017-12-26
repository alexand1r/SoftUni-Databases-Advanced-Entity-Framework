using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.HospitalDatabase
{
    class HospitalDatabase
    {
        static void Main(string[] args)
        {
            var context = new HospitalContext();
            context.Database.Initialize(true);
        }
    }
}
