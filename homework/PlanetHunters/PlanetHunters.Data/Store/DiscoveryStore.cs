using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public class DiscoveryStore
    {
        private static bool hasError;
        public static void AddDiscovery(List<DiscoveryDto> discoveries)
        {
            using (var context = new PlanetHuntersEntities())
            {
                foreach (var discoveryDto in discoveries)
                {
                    foreach (var star in discoveryDto.Stars)
                    {
                        var exists = GetStarByName(star);
                        if (exists == null)
                        {
                            hasError = true;
                            Console.WriteLine("Invalid data format.");
                        }
                        else hasError = false;
                    }

                    foreach (var planet in discoveryDto.Planets)
                    {
                        var exists = GetPlanetByName(planet);
                        if (exists == null)
                        {
                            hasError = true;
                            Console.WriteLine("Invalid data format.");
                        }
                        else hasError = false;
                    }

                    foreach (var astronomer in discoveryDto.Pioneers)
                    {
                        var exists = GetAstronomerByName(astronomer);
                        if (exists == null)
                        {
                            hasError = true;
                            Console.WriteLine("Invalid data format.");
                        }
                        else hasError = false;
                    }

                    foreach (var astronomer in discoveryDto.Observers)
                    {
                        var exists = GetAstronomerByName(astronomer);
                        if (exists == null)
                        {
                            hasError = true;
                            Console.WriteLine("Invalid data format.");
                        }
                        else hasError = false;
                    }

                    if (!hasError)
                    {
                        var discovery = new Discovery()
                        {
                            Date = DateTime.Parse(discoveryDto.Date),
                            TelescopeId = context.Telescopes.FirstOrDefault(t => t.Name == discoveryDto.Telescope).Id,
                        };
                        context.Discoveries.Add(discovery);
                        
                        foreach (var name in discoveryDto.Stars)
                        {
                           discovery.Stars.Add(context.Stars.FirstOrDefault(p => p.Name == name));
                        }

                        foreach (var name in discoveryDto.Planets)
                        {
                            discovery.Planets.Add(context.Planets.FirstOrDefault(p => p.Name == name));
                        }

                        foreach (var name in discoveryDto.Pioneers)
                        {
                            string[] data = name.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            discovery.Pioneers.Add(context.Astronomers.FirstOrDefault(p => p.FirstName == data[0] && p.LastName == data[1]));
                        }

                        foreach (var name in discoveryDto.Stars)
                        {
                            string[] data = name.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            discovery.Observers.Add(context.Astronomers.FirstOrDefault(p => p.FirstName == data[0] && p.LastName == data[1]));
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Planet GetPlanetByName(string name)
        {
            using (var context = new PlanetHuntersEntities())
            {
                return context.Planets.FirstOrDefault(p => p.Name == name);
            }
        }

        public static Star GetStarByName(string name)
        {
            using (var context = new PlanetHuntersEntities())
            {
                return context.Stars.FirstOrDefault(p => p.Name == name);
            }
        }

        public static Astronomer GetAstronomerByName(string astronomer)
        {
            using (var context = new PlanetHuntersEntities())
            {
                string[] data = astronomer.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                return context.Astronomers.FirstOrDefault(p => p.FirstName == data[0] && p.LastName == data[1]);
            }
        }
    }
}
