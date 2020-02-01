namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRefTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContPaperReceipts", "refType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContPaperReceipts", "refType", c => c.String());
        }
    }
}
