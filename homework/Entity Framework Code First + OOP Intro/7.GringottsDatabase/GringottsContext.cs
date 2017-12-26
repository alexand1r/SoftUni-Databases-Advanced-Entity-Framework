using System.ComponentModel.DataAnnotations.Schema;

namespace _7.GringottsDatabase
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class GringottsContext : DbContext
    {
        // Your context has been configured to use a 'GringottsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_7.GringottsDatabase.GringottsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GringottsContext' 
        // connection string in the application configuration file.
        public GringottsContext()
            : base("GringottsContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<WizardDeposits> WizardDepositses { get; set; }
    }

    public class WizardDeposits
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        [MaxLength(1000)]
        public string Notes { get; set; }
        public uint Age { get; set; }
        [MaxLength(100)]
        public string MagicWandCreator { get; set; }
        public uint MagicWandSize { get; set; }
        [MaxLength(20)]
        public string DepositGroup { get; set; }
        public DateTime DepositStartDate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal DepositInterest { get; set; }
        public decimal DepositCharge { get; set; }
        public DateTime DepositExpirationDate { get; set; }
        public bool IsDepositExpired { get; set; }
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}