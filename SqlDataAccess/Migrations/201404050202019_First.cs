namespace SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Laptops",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Summary = c.String(),
                        Memory = c.Int(nullable: false),
                        HardDisk = c.Int(nullable: false),
                        ScreenSize = c.Int(nullable: false),
                        Processor = c.String(),
                        OperatingSystem = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Laptops");
        }
    }
}
