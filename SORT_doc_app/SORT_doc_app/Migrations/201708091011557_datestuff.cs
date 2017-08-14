namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datestuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "GoLiveDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "GoLiveDate");
        }
    }
}
