using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Product
    {
        public int id { get; set; }
        public string NameProduct { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice {  get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; }
        public DateTime RegDate { get; set; }

        public string Category { get; set; }
        public string Size {  get; set; }
        public string Color { get; set; }  
        
        public List<Invoice> Invoices { get; set; }= new List<Invoice>();
        public List<ProductRunningOut> ProductRunningOuts { get; set; } = new List<ProductRunningOut>();
        public Report Report { get; set; } 
        
    }
}
