namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ContPaperPayments", "refType");
            AddForeignKey("dbo.ContPaperPayments", "refType", "dbo.LKRefTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContPaperPayments", "refType", "dbo.LKRefTypes");
            DropIndex("dbo.ContPaperPayments", new[] { "refType" });
        }
    }
}
