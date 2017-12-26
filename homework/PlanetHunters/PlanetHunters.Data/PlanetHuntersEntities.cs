using PlanetHunters.Data.Migrations;
using PlanetHunters.Models;

namespace PlanetHunters.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHuntersEntities : DbContext
    {
        public PlanetHuntersEntities()
            : base("name=PlanetHuntersEntities")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PlanetHuntersEntities>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PlanetHuntersEntities, Configuration>());
        }

        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>().Property(t => t.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Astronomer>().Property(t => t.LastName).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.PioneerDiscoveries)
                .WithMany(pd => pd.Pioneers)
                .Map(apd =>
                {
                    apd.MapLeftKey("PioneerId");
                    apd.MapRightKey("PioneerDiscoveryId");
                    apd.ToTable("PioneersPioneerDiscoveries");
                });

            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.ObserverDiscoveries)
                .WithMany(od => od.Observers)
                .Map(aod =>
                {
                    aod.MapLeftKey("ObserverId");
                    aod.MapRightKey("ObserverDiscoveryId");
                    aod.ToTable("ObserversObserverDiscoveries");
                });

            //----------------------------

            //modelBuilder.Entity<Discovery>().Property(t => t.Date).IsRequired();

            //---------------------------

            modelBuilder.Entity<Telescope>().Property(t => t.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Telescope>().Property(t => t.Location).HasMaxLength(255).IsRequired();

            //---------------------------

            modelBuilder.Entity<StarSystem>().Property(t => t.Name).HasMaxLength(255).IsRequired();

            //---------------------------

            modelBuilder.Entity<Star>().Property(t => t.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Star>()
                .HasRequired(s => s.StarSystem)
                .WithMany(ss => ss.Stars)
                .WillCascadeOnDelete(false);

            //---------------------------

            modelBuilder.Entity<Planet>().Property(t => t.Name).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Planet>()
                .HasRequired(s => s.StarSystem)
                .WithMany(ss => ss.Planets)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}