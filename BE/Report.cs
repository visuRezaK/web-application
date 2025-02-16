using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Report
    {
        public int id {  get; set; }
        public string Product { get; set; }
        public string Customers { get; set; }
        public string Invoice { get; set; }
        public string Category { get; set; }
        public string Users { get; set; }
        public string ProductRunningOut { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<ProductRunningOut> ProductRunningOuts { get; set; } = new List<ProductRunningOut>();
        public List <Product> Products { get; set; } = new List<Product>();
        public User_Login User { get; set; }
        public Customer Customer { get; set; }
    }
}
