using PlanetHunters.Models;

namespace PlanetHunters.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlanetHunters.Data.PlanetHuntersEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PlanetHunters.Data.PlanetHuntersEntities";
        }

        protected override void Seed(PlanetHunters.Data.PlanetHuntersEntities context)
        {

            //foreach (Discovery d in context.Discoveries)
            //{
            //    var pub = new Publication()
            //    {
            //        ReleaseDate = d.Date,
            //        DiscoveryId = d.Id
            //    };
            //
            //    context.Publications.AddOrUpdate(pub);
            //}

            var pubFirst = context.Publications.FirstOrDefault();
            var pubLast = context.Publications.LastOrDefault();

            var journal = new Journal()
            {
                Name = "Journal1"
            };

            journal.Publications.Add(pubFirst);
            journal.Publications.Add(pubLast);

            context.Journals.AddOrUpdate(journal);
        }
    }
}
