namespace Shajol_POS_PTSL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailsId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        productName = c.String(),
                        productUnitPrice = c.Int(nullable: false),
                        totalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailsId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceDetailsId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        productName = c.String(),
                        productAmount = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
        }
    }
}
