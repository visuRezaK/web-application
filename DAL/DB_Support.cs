using BE;
using System.Data.Entity;



namespace DAL
{
    public class DB_Support : DbContext
    {
        public DB_Support() :base("cons") { }
        public DbSet<User_Login> Users { get; set; }
        public DbSet<User_Picture> Picture { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ProductRunningOut> ProductRunningOuts { get; set;}
        public DbSet<ChangePassword> changePasswords { get; set; }

    }
     

}
