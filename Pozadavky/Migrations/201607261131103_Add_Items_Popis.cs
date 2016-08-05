namespace Pozadavky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Items_Popis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "CelkovyPopis", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "CelkovyPopis");
        }
    }
}
