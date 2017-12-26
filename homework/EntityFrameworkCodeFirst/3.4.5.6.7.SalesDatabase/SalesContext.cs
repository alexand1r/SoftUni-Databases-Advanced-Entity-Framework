using _3.SalesDatabase.Migrations;

namespace _3.SalesDatabase
{
    using _3.SalesDatabase.Models;
    using System.Data.Entity;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            //Database.SetInitializer(new InitializeAndSeed());
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations{ get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}