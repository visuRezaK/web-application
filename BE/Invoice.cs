using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Invoice
    {
        public int id {  get; set; }
        public int InvoiceNum { get; set; }
        public double SalePrice {  get; set; }
        public double Total {  get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public string shop { get; set; }
        public DateTime Date { get; set; }
       // public bool Status { get; set; }
        public DateTime CheckoutDate { get; set; }
        public Customer Customer { get; set; }
        public User_Login User { get; set; } = new User_Login();
        public List<Product> Products { get; set; } = new List<Product>();
        public Report Report { get; set; }

    }
}
