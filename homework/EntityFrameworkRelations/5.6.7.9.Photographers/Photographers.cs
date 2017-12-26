using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Photographers
{
    class Photographers
    {
        static void Main(string[] args)
        {
            var context = new PhotographersContext();
            context.Database.Initialize(true);
        }
    }
}
