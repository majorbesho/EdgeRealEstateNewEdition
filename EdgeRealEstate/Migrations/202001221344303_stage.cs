namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerSelectFlats", "CostMony", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerSelectFlats", "Vat");
            DropTable("dbo.CustomerSelectFlatViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerSelectFlatViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        FlatId = c.Int(nullable: false),
                        Flatname = c.String(),
                        BuildingId = c.Int(nullable: false),
                        BuildingCode = c.String(),
                        Projectid = c.Int(nullable: false),
                        ProjectName = c.String(),
                        CurrntlyDate = c.DateTime(),
                        CostMony = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.CustomerSelectFlats", "Vat", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CustomerSelectFlats", "CostMony", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
