namespace AutoWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterModifyLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "LocalName", c => c.String());
            DropColumn("dbo.Location", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Location", c => c.String());
            DropColumn("dbo.Location", "LocalName");
        }
    }
}
