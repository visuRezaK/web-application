using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class Runningout_Product_DAL
    {
        DB_Support db = new DB_Support();


        public Product Read(int id)
        {
            return db.Products.Where(i => i.id == id).FirstOrDefault();
        }
        public Product ReadP(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> Read()
        {
            return db.Products.ToList();
        }
        public DataTable Readp(string s, int index)
        {
            SqlCommand cmd = new SqlCommand();
            if (index == 0)
            {
                cmd.CommandText = ("dbo.SearchProduct");
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

    }
}
