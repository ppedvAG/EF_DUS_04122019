namespace HalloEF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stand_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stand", t => t.Stand_Id)
                .Index(t => t.Stand_Id);
            
            CreateTable(
                "dbo.Stand",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Besitzer = c.String(nullable: false, maxLength: 25),
                        Name = c.String(),
                        Typ = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Market",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        City = c.String(maxLength: 76),
                        Email = c.String(),
                        Von = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Bis = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarktStand",
                c => new
                    {
                        Markt_Id = c.Long(nullable: false),
                        Stand_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Markt_Id, t.Stand_Id })
                .ForeignKey("dbo.Market", t => t.Markt_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stand", t => t.Stand_Id, cascadeDelete: true)
                .Index(t => t.Markt_Id)
                .Index(t => t.Stand_Id);
            
            CreateTable(
                "dbo.Essen",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        KCal = c.Int(nullable: false),
                        Vegan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produkt", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Getraenk",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Alk = c.Int(nullable: false),
                        Farbe = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produkt", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Plunder",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Material = c.String(),
                        Glaenzt = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produkt", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plunder", "Id", "dbo.Produkt");
            DropForeignKey("dbo.Getraenk", "Id", "dbo.Produkt");
            DropForeignKey("dbo.Essen", "Id", "dbo.Produkt");
            DropForeignKey("dbo.Produkt", "Stand_Id", "dbo.Stand");
            DropForeignKey("dbo.MarktStand", "Stand_Id", "dbo.Stand");
            DropForeignKey("dbo.MarktStand", "Markt_Id", "dbo.Market");
            DropIndex("dbo.Plunder", new[] { "Id" });
            DropIndex("dbo.Getraenk", new[] { "Id" });
            DropIndex("dbo.Essen", new[] { "Id" });
            DropIndex("dbo.MarktStand", new[] { "Stand_Id" });
            DropIndex("dbo.MarktStand", new[] { "Markt_Id" });
            DropIndex("dbo.Produkt", new[] { "Stand_Id" });
            DropTable("dbo.Plunder");
            DropTable("dbo.Getraenk");
            DropTable("dbo.Essen");
            DropTable("dbo.MarktStand");
            DropTable("dbo.Market");
            DropTable("dbo.Stand");
            DropTable("dbo.Produkt");
        }
    }
}
