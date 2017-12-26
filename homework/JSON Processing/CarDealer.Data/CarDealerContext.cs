using CarDealer.Data.Migrations;
using CarDealer.Models;

namespace CarDealer.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("name=CarDealerContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CarDealerContext, Configuration>());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Part>()
                .HasMany(p => p.Cars)
                .WithMany(c => c.Parts)
                .Map(pc =>
                {
                    pc.ToTable("PartCars");
                    pc.MapLeftKey("PartId");
                    pc.MapRightKey("CarId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}