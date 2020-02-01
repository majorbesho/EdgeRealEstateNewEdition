namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRefTypes1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LKRefTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        CridetDebit = c.Int(nullable: false),
                        Aname = c.String(),
                        Ename = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LKRefTypes");
        }
    }
}
