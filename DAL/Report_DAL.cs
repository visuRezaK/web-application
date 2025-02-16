using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Report_DAL
    {
        DB_Support db = new DB_Support();

        public DataTable Read(string s, int index)
        {
            SqlCommand cmd = new SqlCommand();
            if (index == 0)
            {
                cmd.CommandText = ("dbo.InvoiceCustomer1");

            }
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NMKICFI\\SQLEXPRESS;Initial Catalog=Rumishop;Integrated Security=true;");


            cmd.Parameters.AddWithValue("@search", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];

        }
        public bool Read(Customer c)
        {

            return db.Customers.Any(i => i.Name == c.Name && i.Phone == c.Phone);
        }
        public List<Invoice> Read()
        {
            return db.Invoices.ToList();
        }
        public Customer Read(int id)
        {
            return db.Customers.Where(i => i.id == id).SingleOrDefault();
        }

    }
}
