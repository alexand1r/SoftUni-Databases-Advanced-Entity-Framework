using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Store
{
    public class TelescopeStore
    {
        public static void AddTelescope(IEnumerable<TelescopeDto> telescopes)
        {
            using (var context = new PlanetHuntersEntities())
            {
                foreach (var telescope in telescopes)
                {
                    if (telescope.Name == null 
                        || telescope.Location == null
                        || telescope.MirrorDiameter == null 
                        || decimal.Parse(telescope.MirrorDiameter) <= 0.0M)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        context.Telescopes.Add(new Telescope
                        {
                            Name = telescope.Name,
                            Location = telescope.Location,
                            MirrorDiameter = decimal.Parse(telescope.MirrorDiameter)
                        });
                        Console.WriteLine($"Record {telescope.Name} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static Telescope GetTelescopeByName(string name)
        {
            using (var context = new PlanetHuntersEntities())
            {
                return context.Telescopes.FirstOrDefault(t => t.Name == name);
            }
        }
    }
}
