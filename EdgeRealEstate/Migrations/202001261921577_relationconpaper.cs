namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationconpaper : DbMigration
    {
        public override void Up()
        {
            //CreateIndex("dbo.ContPaperReceipts", "refType");
            //AddForeignKey("dbo.ContPaperReceipts", "refType", "dbo.LKRefTypes", "Code");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.ContPaperReceipts", "refType", "dbo.LKRefTypes");
            //DropIndex("dbo.ContPaperReceipts", new[] { "refType" });
        }
    }
}
