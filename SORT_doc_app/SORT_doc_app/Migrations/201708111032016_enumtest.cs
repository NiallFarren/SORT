namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumtest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnumTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EnumTests");
        }
    }
}
