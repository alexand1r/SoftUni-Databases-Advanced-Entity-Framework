using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystem.Data;

namespace RestaurantSystem.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new RestaurantSystemContext();
            context.Database.Initialize(true);


        }
    }
}
