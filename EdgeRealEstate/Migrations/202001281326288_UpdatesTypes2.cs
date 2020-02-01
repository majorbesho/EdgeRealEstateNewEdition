namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesTypes2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContributerPaymentForProjectVMs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customerId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        toDate = c.DateTime(nullable: false),
                        custName = c.String(),
                        paidMethod = c.String(),
                        salesManName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContributerPaymentForProjectVMs");
        }
    }
}
