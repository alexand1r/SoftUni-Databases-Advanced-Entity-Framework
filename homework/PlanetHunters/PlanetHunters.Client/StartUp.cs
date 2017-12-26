using PlanetHunters.Data;

namespace PlanetHunters.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new PlanetHuntersEntities();
            context.Database.Initialize(true);
        }
    }
}
