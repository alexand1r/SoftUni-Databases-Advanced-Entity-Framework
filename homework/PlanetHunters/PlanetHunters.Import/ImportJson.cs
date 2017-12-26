using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Data.Store;

namespace PlanetHunters.Import
{
    public class ImportJson
    {
        public static void ImportAstronomers()
        {
            var json = File.ReadAllText("../../../datasets/astronomers.json");
            var astronomers = JsonConvert.DeserializeObject<IEnumerable<AstronomerDto>>(json);
            AstronomerStore.AddAstronomer(astronomers);
        }

        public static void ImportTelescopes()
        {
            var json = File.ReadAllText("../../../datasets/telescopes.json");
            var telescopes = JsonConvert.DeserializeObject<IEnumerable<TelescopeDto>>(json);
            TelescopeStore.AddTelescope(telescopes);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText("../../../datasets/planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            PlanetStore.AddPlanet(planets);
        }
    }
}
