namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ruv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Tax", c => c.Double(nullable: false));
            AddColumn("dbo.User_Picture", "Username", c => c.String());
            AddColumn("dbo.User_Picture", "Password", c => c.String());
            AddColumn("dbo.User_Picture", "Repassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Picture", "Repassword");
            DropColumn("dbo.User_Picture", "Password");
            DropColumn("dbo.User_Picture", "Username");
            DropColumn("dbo.Invoices", "Tax");
        }
    }
}
