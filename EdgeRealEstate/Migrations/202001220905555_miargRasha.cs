namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miargRasha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LKPaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContPaperPayments", "ProjectId", c => c.Int());
            AddColumn("dbo.ContPaperReceipts", "ProjectId", c => c.Int());
            CreateIndex("dbo.ContPaperPayments", "ProjectId");
            CreateIndex("dbo.ContPaperReceipts", "ProjectId");
            AddForeignKey("dbo.ContPaperReceipts", "ProjectId", "dbo.Project", "id");
            AddForeignKey("dbo.ContPaperPayments", "ProjectId", "dbo.Project", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContPaperPayments", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ContPaperReceipts", "ProjectId", "dbo.Project");
            DropIndex("dbo.ContPaperReceipts", new[] { "ProjectId" });
            DropIndex("dbo.ContPaperPayments", new[] { "ProjectId" });
            DropColumn("dbo.ContPaperReceipts", "ProjectId");
            DropColumn("dbo.ContPaperPayments", "ProjectId");
            DropTable("dbo.LKPaymentMethods");
        }
    }
}
