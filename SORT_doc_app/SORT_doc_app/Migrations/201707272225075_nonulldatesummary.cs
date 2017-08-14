namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nonulldatesummary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Summaries", "GoLiveDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Summaries", "GoLiveDate", c => c.DateTime());
        }
    }
}
