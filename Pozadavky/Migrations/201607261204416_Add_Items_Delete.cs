namespace Pozadavky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Items_Delete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Smazano", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "SmazalUzivatel", c => c.String());
            AddColumn("dbo.Items", "SmazanoDne", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "SmazanoDne");
            DropColumn("dbo.Items", "SmazalUzivatel");
            DropColumn("dbo.Items", "Smazano");
        }
    }
}
