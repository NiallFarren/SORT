namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumtestgone : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EnumTests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EnumTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
