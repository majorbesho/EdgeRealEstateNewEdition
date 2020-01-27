namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conpaper1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContributerMoveViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ContributorId = c.Int(nullable: false),
                        ContributorName = c.String(),
                        refTypeCredit = c.Int(nullable: false),
                        RefnameCredit = c.String(),
                        indateCredit = c.DateTime(nullable: false),
                        paidCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        refTypeDebit = c.Int(nullable: false),
                        RefnameDebit = c.String(),
                        indateDebit = c.DateTime(nullable: false),
                        paidDebit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDebit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContributerMoveViewModels");
        }
    }
}
