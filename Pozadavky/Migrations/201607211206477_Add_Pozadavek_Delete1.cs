namespace Pozadavky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Pozadavek_Delete1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pozadavky", "SmazanoDne", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pozadavky", "SmazanoDne");
        }
    }
}
