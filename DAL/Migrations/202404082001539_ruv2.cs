namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ruv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "shop", c => c.String());
            DropColumn("dbo.Products", "shop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "shop", c => c.String());
            DropColumn("dbo.Invoices", "shop");
        }
    }
}
