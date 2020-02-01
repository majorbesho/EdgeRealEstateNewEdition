namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypes1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContPaperPayments", "paidMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContPaperPayments", "paidMethod", c => c.String());
        }
    }
}
