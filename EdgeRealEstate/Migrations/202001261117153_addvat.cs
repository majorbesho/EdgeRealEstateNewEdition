namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerSelectFlats", "Vat", c => c.Decimal(nullable: true, precision: 18, scale: 2));
          
        }
        
        public override void Down()
        {
            
            AlterColumn("dbo.CustomerSelectFlats", "Vat", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
