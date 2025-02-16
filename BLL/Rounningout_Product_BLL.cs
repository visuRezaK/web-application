using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using DAL.Relations_DAL;
using System.Windows.Forms;

namespace BLL
{
    public class Rounningout_Product_BLL
    {
        Product_DAL dAL = new Product_DAL();
        public Product Read(int id)
        {
            return dAL.Read(id);
        }

        public List<Product> Read()
        {
            return dAL.Read();
        }
        public Product ReadP(int p)
        {
            return dAL.ReadP(p);
        }
        public DataTable Readp(string s, int index)
        {
            return dAL.Readp(s, index);
        }
    }
}
