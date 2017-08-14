namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class events : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        _Date = c.DateTime(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        EventBody = c.String(nullable: false, maxLength: 160),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Events", new[] { "ProjectID" });
            DropTable("dbo.Events");
        }
    }
}
