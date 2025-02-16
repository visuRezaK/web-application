using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relations_DAL;


namespace BLL.Relations_BLL
{
    public class Customer_BLL
    {
        Customer_DAL dal=new Customer_DAL();
        public string Create(Customer c)
        {
           // if (dal.Read(c))
          //  {
                return dal.Create(c);
         //   }
        //    else
        //    {
        //        return "A user with this contact number is registered in the system!";
        //    }
           
        }

        public bool Read(Customer c)
        {
            return dal.Read(c);
        }

        public List<Customer> Read()
        {
            return dal.Read(); 
        }

        public Customer Read(int id)
        {
            return dal.Read(id);
        }
        public DataTable Read(string s,int index)
        {
            return dal.Read(s,index);
        }

        public string Update(int id, Customer cnew)
        {
            return dal.Update(id, cnew);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
