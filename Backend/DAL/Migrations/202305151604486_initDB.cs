namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(nullable: false),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatId, cascadeDelete: true)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        UId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Contact = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tkey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UId", "dbo.Users");
            DropForeignKey("dbo.Products", "CatId", "dbo.Catagories");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "UId" });
            DropIndex("dbo.Products", new[] { "CatId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
