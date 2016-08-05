namespace Pozadavky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dodavatele",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazev = c.String(nullable: false, maxLength: 100),
                        Adresa = c.String(maxLength: 100),
                        IC = c.String(maxLength: 10),
                        DIC = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pozadavky",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Popis = c.String(maxLength: 100),
                        Jednotka = c.String(maxLength: 10),
                        Mnozstvi = c.Int(nullable: false),
                        CenaZaJednotku = c.Single(nullable: false),
                        CelkovaCena = c.Single(nullable: false),
                        DatumObjednani = c.DateTime(nullable: false),
                        TerminDodani = c.DateTime(nullable: false),
                        Mena = c.String(maxLength: 3),
                        DodavatelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Dodavatele", t => t.DodavatelId)
                .Index(t => t.ItemId)
                .Index(t => t.DodavatelId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PozadavekID = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 50),
                        FullPath = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pozadavky", t => t.PozadavekID, cascadeDelete: true)
                .Index(t => t.PozadavekID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vlozil = c.String(nullable: false, maxLength: 60),
                        Datum = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pozadavky", "DodavatelId", "dbo.Dodavatele");
            DropForeignKey("dbo.Pozadavky", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Files", "PozadavekID", "dbo.Pozadavky");
            DropIndex("dbo.Files", new[] { "PozadavekID" });
            DropIndex("dbo.Pozadavky", new[] { "DodavatelId" });
            DropIndex("dbo.Pozadavky", new[] { "ItemId" });
            DropTable("dbo.Items");
            DropTable("dbo.Files");
            DropTable("dbo.Pozadavky");
            DropTable("dbo.Dodavatele");
        }
    }
}
