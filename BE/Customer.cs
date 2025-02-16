using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Customer
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public DateTime RegDate { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
      //  public Report Report { get; set; }
    }
}
