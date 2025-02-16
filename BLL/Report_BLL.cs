using BE;
using DAL;
using DAL.Relations_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class Report_BLL
    {

      
        Report_DAL dal = new Report_DAL();

        public bool Read(Customer c)
        {
            return dal.Read(c);
        }
        public DataTable Read(string s, int index)
        {
            return dal.Read(s, index);
        }
        public List<Invoice> Read()
        {
            return dal.Read();
        }
        public Customer Read(int id)
        {
            return dal.Read(id);
        }
    }
}
