using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data.DTOs
{
    public class PlanetByTelescopeDto
    {
        public string Name { get; set; }
        public string Mass { get; set; }
        public string[] Orbitting { get; set; }
    }
}
