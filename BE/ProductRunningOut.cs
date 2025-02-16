using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductRunningOut
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string Status { get; set; }
        public List<Product>Products { get; set; }=new List<Product>();
        public Report Report { get; set; }
       
    }
}
