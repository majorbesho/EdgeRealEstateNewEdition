namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ContPaperPayments", new[] { "DbtrefType" });
            DropIndex("dbo.ContPaperReceipts", new[] { "CrdrefType" });
            AlterColumn("dbo.ContPaperPayments", "refID", c => c.Int());
            AlterColumn("dbo.ContPaperPayments", "DbtrefType", c => c.Int());
            AlterColumn("dbo.ContPaperReceipts", "refID", c => c.Int());
            AlterColumn("dbo.ContPaperReceipts", "CrdrefType", c => c.Int());
            CreateIndex("dbo.ContPaperPayments", "DbtrefType");
            CreateIndex("dbo.ContPaperReceipts", "CrdrefType");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContPaperReceipts", new[] { "CrdrefType" });
            DropIndex("dbo.ContPaperPayments", new[] { "DbtrefType" });
            AlterColumn("dbo.ContPaperReceipts", "CrdrefType", c => c.Int(nullable: false));
            AlterColumn("dbo.ContPaperReceipts", "refID", c => c.Int(nullable: false));
            AlterColumn("dbo.ContPaperPayments", "DbtrefType", c => c.Int(nullable: false));
            AlterColumn("dbo.ContPaperPayments", "refID", c => c.Int(nullable: false));
            CreateIndex("dbo.ContPaperReceipts", "CrdrefType");
            CreateIndex("dbo.ContPaperPayments", "DbtrefType");
        }
    }
}
