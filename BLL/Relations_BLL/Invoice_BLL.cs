using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relations_DAL;
using System.Data;

namespace BLL.Relations_BLL
{
    public class Invoice_BLL
    {
        Invoice_DAL dal= new Invoice_DAL();
        public string Create(Invoice I, int cid, List<int> pid)
        {
            if(cid !=0)
            {
                return dal.Create(I, cid, pid);
            }
            else
            {
                return "Please select the customer for the invoice!";
            }
        }
        public int ReadInvoiceNum()
        {
            return dal.ReadInvoiceNum();
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable Readp()
        {
            return dal.Read();
        }

        public DataTable Read(string s, int index)
        {
            return dal.Read(s, index);
        }
    }
}
