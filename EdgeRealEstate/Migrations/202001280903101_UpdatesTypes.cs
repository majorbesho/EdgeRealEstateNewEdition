namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesTypes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ContPaperPayments", name: "refType", newName: "DbtrefType");
            RenameColumn(table: "dbo.ContPaperReceipts", name: "refType", newName: "CrdrefType");
            RenameIndex(table: "dbo.ContPaperPayments", name: "IX_refType", newName: "IX_DbtrefType");
            RenameIndex(table: "dbo.ContPaperReceipts", name: "IX_refType", newName: "IX_CrdrefType");
            AddColumn("dbo.ContPaperPayments", "Dbtpaid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ContPaperPayments", "Dbtnotes", c => c.String());
            AddColumn("dbo.ContPaperPayments", "Dbtindate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContPaperReceipts", "Crdpaid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ContPaperReceipts", "Crdnotes", c => c.String());
            AddColumn("dbo.ContPaperReceipts", "Crdindate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ContPaperPayments", "paid");
            DropColumn("dbo.ContPaperPayments", "notes");
            DropColumn("dbo.ContPaperPayments", "indate");
            DropColumn("dbo.ContPaperReceipts", "paid");
            DropColumn("dbo.ContPaperReceipts", "notes");
            DropColumn("dbo.ContPaperReceipts", "indate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContPaperReceipts", "indate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContPaperReceipts", "notes", c => c.String());
            AddColumn("dbo.ContPaperReceipts", "paid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ContPaperPayments", "indate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContPaperPayments", "notes", c => c.String());
            AddColumn("dbo.ContPaperPayments", "paid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ContPaperReceipts", "Crdindate");
            DropColumn("dbo.ContPaperReceipts", "Crdnotes");
            DropColumn("dbo.ContPaperReceipts", "Crdpaid");
            DropColumn("dbo.ContPaperPayments", "Dbtindate");
            DropColumn("dbo.ContPaperPayments", "Dbtnotes");
            DropColumn("dbo.ContPaperPayments", "Dbtpaid");
            RenameIndex(table: "dbo.ContPaperReceipts", name: "IX_CrdrefType", newName: "IX_refType");
            RenameIndex(table: "dbo.ContPaperPayments", name: "IX_DbtrefType", newName: "IX_refType");
            RenameColumn(table: "dbo.ContPaperReceipts", name: "CrdrefType", newName: "refType");
            RenameColumn(table: "dbo.ContPaperPayments", name: "DbtrefType", newName: "refType");
        }
    }
}
