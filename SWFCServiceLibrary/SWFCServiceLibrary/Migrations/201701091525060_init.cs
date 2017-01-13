namespace SWFCServiceLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SendTo = c.String(),
                        MessagePosted = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderProductId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderProductId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.WallDatas",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        MessagePosted = c.DateTime(nullable: false),
                        MessageContent = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropTable("dbo.WallDatas");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Chats");
        }
    }
}
