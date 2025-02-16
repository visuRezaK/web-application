using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using DAL.Relations_DAL;

namespace BLL.Relations_BLL
{
    public class Product_BLL
    {
        Product_DAL dal = new Product_DAL();
        public string Create(Product p)
        {
            return dal.Create(p);
        }
        public bool Read(Product p)
        {
            return dal.Read(p);
        }
        public int FindId(string name)
        {

            return dal.FindId(name);
        }
     

        public List<Product> Read()
        {
            return dal.Read();
        }
        public Product Read(int id)
        {
            return dal.Read(id);
        }
        public string Update(int id, Product pnew)
        {
            return dal.Update(id, pnew);
        }
        public string Delete(int id) 
        {
            return dal.Delete(id);
        }

        public List<string> ReadNameProduct()
        {
            return dal.ReadNameProduct();
        }
        public List<string> ReadBarcode()
        {
            return dal.ReadBarcode();
        }

        public Product ReadP(int p)
        {
            return dal.ReadP(p);
        }
        public DataTable Readp(string s, int index)
        {
            return dal.Readp(s, index);
        }
    }
   
}
