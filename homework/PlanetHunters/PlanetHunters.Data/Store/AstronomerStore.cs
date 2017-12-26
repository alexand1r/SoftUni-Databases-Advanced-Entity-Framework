using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public class AstronomerStore
    {
        public static void AddAstronomer(IEnumerable<AstronomerDto> astronomers)
        {
            using (var context = new PlanetHuntersEntities())
            {
                foreach (var astronomer in astronomers)
                {
                    if (astronomer.FirstName == null || astronomer.LastName == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        context.Astronomers.Add(new Astronomer
                        {
                            FirstName = astronomer.FirstName,
                            LastName = astronomer.LastName
                        });
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
