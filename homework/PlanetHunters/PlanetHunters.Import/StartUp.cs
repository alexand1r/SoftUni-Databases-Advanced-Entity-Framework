using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Import
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ImportJson.ImportAstronomers();
            ImportJson.ImportTelescopes();
            ImportJson.ImportPlanets();
            ImportXml.ImportStars();
            ImportXml.ImportDiscoveries();
        }
    }
}
