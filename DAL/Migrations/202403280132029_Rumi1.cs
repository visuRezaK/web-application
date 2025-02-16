namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rumi1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Login", "Repassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Login", "Repassword");
        }
    }
}
