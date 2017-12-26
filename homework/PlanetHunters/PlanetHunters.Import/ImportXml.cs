using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PlanetHunters.Data.DTOs;
using PlanetHunters.Data.Store;

namespace PlanetHunters.Import
{
    public class ImportXml
    {
        public static void ImportStars()
        {
            XDocument xml = XDocument.Load("../../../datasets/stars.xml");
            var stars = xml.Root.Elements();
            var result = new List<StarDto>();

            foreach (var star in stars)
            {
                try
                {
                    var starDto = new StarDto()
                    {
                        Name = star.Element("Name").Value,
                        Temperature = star.Element("Temperature").Value,
                        StarSystem = star.Element("StarSystem").Value
                    };

                    result.Add(starDto);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: Invalid data format.");
                }
            }

            StarStore.AddStars(result);
        }

        public static void ImportDiscoveries()
        {
            XDocument xml = XDocument.Load("../../../datasets/discoveries.xml");
            var discoveries = xml.Root.Elements();
            var result = new List<DiscoveryDto>();

            foreach (var discovery in discoveries)
            {
                try
                {
                    var discoveryDto = new DiscoveryDto()
                    {
                        Date = discovery.Attribute("DateMade").Value,
                        Telescope = discovery.Attribute("Telescope").Value,
                        Stars = discovery.Element("Stars").Elements().Select(e => e.Element("Star").Value).ToList(),
                        Planets = discovery.Element("Planets").Elements().Select(e => e.Element("Planet").Value).ToList(),
                        Pioneers = discovery.Element("Pioneers").Elements().Select(e => e.Element("Astronomer").Value).ToList(),
                        Observers = discovery.Element("Observers").Elements().Select(e => e.Element("Astronomer").Value).ToList()
                    };

                    result.Add(discoveryDto);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: Invalid data format.");
                }
            }

            DiscoveryStore.AddDiscovery(result);
        }
    }
}
