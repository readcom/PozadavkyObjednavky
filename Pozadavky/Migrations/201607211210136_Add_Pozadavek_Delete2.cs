namespace Pozadavky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Pozadavek_Delete2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pozadavky", "SmazanoDne", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pozadavky", "SmazanoDne", c => c.DateTime(nullable: false));
        }
    }
}
