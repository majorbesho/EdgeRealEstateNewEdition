namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterLocal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerSelectFlats", "CostMony", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerSelectFlats", "Vat");
            
        }
        
        public override void Down()
        {
            
            
            AddColumn("dbo.CustomerSelectFlats", "Vat", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CustomerSelectFlats", "CostMony", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
