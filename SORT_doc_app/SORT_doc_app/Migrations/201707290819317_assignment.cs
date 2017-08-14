namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Section = c.String(),
                        Assignee = c.String(),
                        _Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Assignments", new[] { "ProjectID" });
            DropTable("dbo.Assignments");
        }
    }
}
