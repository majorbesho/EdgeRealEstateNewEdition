namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesTypes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContributerMoveViewModels", "refTypeCreditID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContributerMoveViewModels", "refTypeCreditID");
        }
    }
}
