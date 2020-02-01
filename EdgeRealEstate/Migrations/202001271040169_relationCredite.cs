namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationCredite : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ContPaperReceipts", "refType");
            AddForeignKey("dbo.ContPaperReceipts", "refType", "dbo.LKRefTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContPaperReceipts", "refType", "dbo.LKRefTypes");
            DropIndex("dbo.ContPaperReceipts", new[] { "refType" });
        }
    }
}
