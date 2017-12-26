using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Models;

namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.Data.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Project.Data.ShopContext context)
        {
            
        }
    }
}
