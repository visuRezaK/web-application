using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL.Relations_DAL
{
    public class Customer_DAL
    {
        DB_Support db=new DB_Support();

        public string Create(Customer c)
        {
            if (!Read(c))
            {
                if (c.Phone.Length == 10)
                {
                    db.Customers.Add(c);
                    db.SaveChanges();
                    return "Information registration has completed successfully";
                }
                else
                {
                    return "The contact number is invalid!";
                }

            }
            else
            {
                return "The entered information is duplicated!";
            }
        }
        public bool Read(Customer c)
        {
            
            return db.Customers.Any(i => i.Name == c.Name && i.Phone == c.Phone);
        }

        public DataTable Read(string s, int index)
        {
            SqlCommand cmd = new SqlCommand();
            if(index == 0)
            {
                cmd.CommandText = ("dbo.SearchCustomer");

            }
            else if(index == 1)
            {

                cmd.CommandText = ("dbo.SearchCustomerName");

            }
            else if(index == 2)
            {
                cmd.CommandText = ("dbo.SearchCustomerPhone");
            }

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NMKICFI\\SQLEXPRESS;Initial Catalog=Rumishop;Integrated Security=true;");

            
            cmd.Parameters.AddWithValue("@search", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds=new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];

        }
        public List<Customer> Read()
        {
            return db.Customers.ToList();
        }
        public Customer Read(int id)
        {
           return db.Customers.Where(i => i.id == id).SingleOrDefault();
        }

        public string Update(int id, Customer cnew)
        {
            Customer c = new Customer();
            c = Read(id);

            c.Name = cnew.Name;
            c.Phone = cnew.Phone;
            c.email = cnew.email;
            c.RegDate = cnew.RegDate;

            db.SaveChanges();
            return "The information edite successfully";
            
        }
        public string Delete(int id)
        {
            Customer c = Read(id);
            db.Customers.Remove(c);
            db.SaveChanges();
            return "The information delete successfully";
        }
    }
}
