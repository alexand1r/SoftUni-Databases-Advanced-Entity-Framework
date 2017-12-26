using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanetHunters.Data;
using PlanetHunters.Data.Store;
using Formatting = System.Xml.Formatting;

namespace PlanetHunters.Export
{
    public class ExportJson
    {
        public static void ExportPlanets(string telescopeName)
        {
            using (var context = new PlanetHuntersEntities())
            {
                var telescope = TelescopeStore.GetTelescopeByName(telescopeName);
                var planets = context.Planets
                    .Where(p => p.Discovery.Telescope.Name == telescope.Name)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Mass = p.Mass,
                        Orbiting = p.StarSystem.Name
                    }).ToList();

                var json = JsonConvert.SerializeObject(planets, Formatting.Indented);

                File.WriteAllText($"../../../planets-by-{telescopeName}.json", json);
            }
        }

        public static void ExportAstronomers(string starSystemName)
        {
            using (var context = new PlanetHuntersEntities())
            {
                var astronomers = context.Astronomers
                    .Where(a => a.ObserverDiscoveries.Any(od => od.Planets.Any(p => p.StarSystem.Name == starSystemName))
                    || a.ObserverDiscoveries.Any(od => od.Stars.Any(s => s.StarSystem.Name == starSystemName))
                    || a.PioneerDiscoveries.Any(pd => pd.Planets.Any(p => p.StarSystem.Name == starSystemName)) 
                    || a.PioneerDiscoveries.Any(pd => pd.Stars.Any(s => s.StarSystem.Name == starSystemName)))
                    .Select(a => new
                    {
                        Name = a.FirstName + " " + a.LastName
                    }).ToList();

                var json = JsonConvert.SerializeObject(astronomers, Formatting.Indented);

                File.WriteAllText($"../../../astronomers-of-{starSystemName}.json", json);
            } 
        }
        
    }
}
