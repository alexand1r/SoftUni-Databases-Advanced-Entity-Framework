using Project.Data.Migrations;
using Project.Models;

namespace Project.Data
{
    using System.Data.Entity;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.BoughtProducts).WithOptional(p => p.Buyer);
            
            modelBuilder.Entity<User>().HasMany(u => u.SelledProducts).WithRequired(p => p.Seller);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .Map(cp =>
                {
                    cp.ToTable("CategoryProducts");
                    cp.MapLeftKey("Category_Id");
                    cp.MapRightKey("Product_Id");
                });

           modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(uf =>
               {
                   uf.ToTable("UserFriends");
                   uf.MapLeftKey("UserId");
                   uf.MapRightKey("FriendId");
               });


            base.OnModelCreating(modelBuilder);
        }
    }
}