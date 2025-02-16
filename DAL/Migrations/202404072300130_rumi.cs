namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rumi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Discount", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Discount", c => c.Single(nullable: false));
            DropColumn("dbo.Invoices", "Discount");
        }
    }
}
