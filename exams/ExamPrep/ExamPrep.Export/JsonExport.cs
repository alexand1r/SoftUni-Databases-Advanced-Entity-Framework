using ExamPrep.Data;
using ExamPrep.Data.Store;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ExamPrep.Export
{
    public class JsonExport
    {
        public static void ExportPlanets()
        {
            var planets = PlanetStore.GetPlanetsWithNoVictims();
            var json = JsonConvert.SerializeObject(planets, Formatting.Indented);

            File.WriteAllText("../../../export/planets.json", json);
        }

        public static void ExportPeople()
        {
            var people = PeopleStore.GetPeopleNotVictims();
            var json = JsonConvert.SerializeObject(people, Formatting.Indented);

            File.WriteAllText("../../../export/people.json", json);
        }
    }
}
