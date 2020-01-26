namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateCOstInCustomeSelectFlat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSelectFlats", "CostMony", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerSelectFlats", "CurrntlyDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerSelectFlats", "CurrntlyDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CustomerSelectFlats", "CostMony");
        }
    }
}
