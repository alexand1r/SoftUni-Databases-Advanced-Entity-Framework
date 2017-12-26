namespace _1.CodeFirstStudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLicencesToResources : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licences", "ResourceId", "dbo.Resources");
            DropIndex("dbo.Licences", new[] { "ResourceId" });
            DropTable("dbo.Licences");
        }
    }
}
