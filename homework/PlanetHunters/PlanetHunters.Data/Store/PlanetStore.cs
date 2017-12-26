using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public class PlanetStore
    {
        private static bool hasNewStarSystem;
        public static void AddPlanet(IEnumerable<PlanetDto> planets)
        {
            using (var context = new PlanetHuntersEntities())
            {
                foreach (var planet in planets)
                {
                    if (planet.Name == null
                        || planet.Mass == null
                        || decimal.Parse(planet.Mass) <= 0.0M
                        || planet.StarSystem == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var starSystem = GetStarSystemByName(planet.StarSystem);
                        if (starSystem == null)
                        {
                            AddStarSystem(planet.StarSystem);
                            hasNewStarSystem = true;
                        }

                        context.Planets.Add(new Planet
                        {
                            Name = planet.Name,
                            Mass = decimal.Parse(planet.Mass),
                            StarSystemId = GetStarSystemByName(planet.StarSystem).Id
                        });
                        Console.WriteLine($"Record {planet.Name} successfully imported.");
                        if (hasNewStarSystem)
                        {
                            Console.WriteLine($"Record {planet.StarSystem} successfully imported.");
                            hasNewStarSystem = false;
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        private static void AddStarSystem(string name)
        {
            using (var context = new PlanetHuntersEntities())
            {
                context.StarSystems.Add(new StarSystem()
                {
                    Name = name
                });
                context.SaveChanges();
            }
        }

        public static StarSystem GetStarSystemByName(string name)
        {
            using (var context = new PlanetHuntersEntities())
            {
                var starSystem = context.StarSystems.FirstOrDefault(s => s.Name == name);

                return starSystem;
            }
        }

    }
}
