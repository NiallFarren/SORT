namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventtype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventType");
        }
    }
}
