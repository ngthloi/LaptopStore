namespace AppleWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id_cart = c.Int(nullable: false, identity: true),
                        id_dev = c.Int(nullable: false),
                        quantity = c.Int(),
                        storage = c.String(),
                    })
                .PrimaryKey(t => t.id_cart)
                .ForeignKey("dbo.Devices", t => t.id_dev, cascadeDelete: true)
                .Index(t => t.id_dev);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        id_dev = c.Int(nullable: false, identity: true),
                        name_dev = c.String(),
                        cost = c.Double(nullable: false),
                        img = c.String(),
                        storage = c.String(),
                        id_cate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_dev)
                .ForeignKey("dbo.Categories", t => t.id_cate, cascadeDelete: true)
                .Index(t => t.id_cate);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id_cate = c.Int(nullable: false, identity: true),
                        name_cate = c.String(),
                    })
                .PrimaryKey(t => t.id_cate);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "id_dev", "dbo.Devices");
            DropForeignKey("dbo.Devices", "id_cate", "dbo.Categories");
            DropIndex("dbo.Devices", new[] { "id_cate" });
            DropIndex("dbo.Carts", new[] { "id_dev" });
            DropTable("dbo.Categories");
            DropTable("dbo.Devices");
            DropTable("dbo.Carts");
        }
    }
}
