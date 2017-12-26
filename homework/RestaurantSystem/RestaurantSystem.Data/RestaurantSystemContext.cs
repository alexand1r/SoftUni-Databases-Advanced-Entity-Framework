using RestaurantSystem.Data.Migrations;
using RestaurantSystem.Models;

namespace RestaurantSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RestaurantSystemContext : DbContext
    {
        public RestaurantSystemContext()
            : base("name=RestaurantSystemContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<RestaurantSystemContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Products)
                .Map(pi =>
                {
                    pi.ToTable("ProductsIngredients");
                    pi.MapLeftKey("ProductId");
                    pi.MapRightKey("IngredientId");
                });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(pc =>
                {
                    pc.ToTable("ProductsCategories");
                    pc.MapLeftKey("ProductId");
                    pc.MapRightKey("CategoryId");
                });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Promotions)
                .WithMany(pr => pr.Products)
                .Map(ppr =>
                {
                    ppr.ToTable("ProductsPromotions");
                    ppr.MapLeftKey("ProductId");
                    ppr.MapRightKey("PromotionId");
                });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(o => o.Products)
                .Map(po =>
                {
                    po.ToTable("ProductsOrders");
                    po.MapLeftKey("ProductId");
                    po.MapRightKey("OrderId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}