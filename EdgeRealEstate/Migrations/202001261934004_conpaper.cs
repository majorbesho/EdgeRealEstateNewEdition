namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conpaper : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContPaperPayments", "refType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContPaperPayments", "refType", c => c.String());
        }
    }
}
