namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rumv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "SalePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "Total", c => c.Double(nullable: false));
            DropColumn("dbo.Invoices", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Invoices", "Total");
            DropColumn("dbo.Invoices", "SalePrice");
        }
    }
}
