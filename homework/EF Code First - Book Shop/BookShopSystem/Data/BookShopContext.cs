using BookShopSystem.Migrations;

namespace BookShopSystem.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id)
                .HasMany(b => b.Categories)
                .WithMany(c => c.Books)
                .Map(cs =>
               {
                   cs.ToTable("CategoryBooks");
                   cs.MapLeftKey("Id");
                   cs.MapRightKey("CategoryId");
               });

            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(cs =>
                {
                    cs.ToTable("RelatedBooks");
                    cs.MapLeftKey("BookId");
                    cs.MapRightKey("RelatedId");
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}