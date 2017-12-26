using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public class StarStore
    {
        private static bool hasNewStarSystem;
        public static void AddStars(List<StarDto> stars)
        {
            using (var context = new PlanetHuntersEntities())
            {
                foreach (var starDto in stars)
                {
                    var starSystem = GetStarSystemByName(starDto.StarSystem);

                    if (int.Parse(starDto.Temperature) < 2400)
                    {
                        Console.WriteLine("Error: Invalid data format.");
                    }
                    else {

                        if (starSystem == null)
                        {
                            AddStarSystem(starDto.StarSystem);
                            hasNewStarSystem = true;
                        }
                    
                        var star = new Star
                        {
                            Name = starDto.Name,
                            Temperature = int.Parse(starDto.Temperature),
                            StarSystemId = GetStarSystemByName(starDto.StarSystem).Id
                        };
                        context.Stars.Add(star);
                        Console.WriteLine($"Record {star.Name} successfully imported.");
                        if (hasNewStarSystem)
                        {
                            Console.WriteLine($"Record {starDto.StarSystem} successfully imported.");
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
