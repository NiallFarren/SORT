namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Status");
        }
    }
}
