using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;

namespace DAL.Relations_DAL
{
    public class Invoice_DAL
    {
        DB_Support dB = new DB_Support();
        public string Create(Invoice I, int cid, List<int> pid)
        {
            I.Date = DateTime.Today;
            I.CheckoutDate = DateTime.Now;
            I.InvoiceNum = SetInvoiceNum();

            #region
            Customer c = dB.Customers.Where(i => i.id == cid).Single();
            I.Customer = c;
           
            #endregion
            //
            #region
            foreach (var item in pid)
            {
                Product p = dB.Products.Where(i => i.id == item).Single();
                if(p.Stock >= 10)
                {
                    p.Stock -= 1;
                }
                else
                {
                    return "Warning! your stock is less than 10";
                }
                
                I.Products.Add(p);
            }
            #endregion
            dB.Invoices.Add(I);
            dB.SaveChanges();
            return "Invoice registration done successfully";
        }

        public bool Read(Invoice I)
        {
            return dB.Invoices.Any(i => i.InvoiceNum == I.InvoiceNum);
        }
        public int ReadInvoiceNum()
        {
            var q=dB.Invoices.OrderByDescending(i => i.id).FirstOrDefault();
            return q.InvoiceNum;
        }
        public int SetInvoiceNum()
        {
            if (dB.Invoices.Count() == 0)
            {
                return 1000;
            }
            else
            {
                return 1000 + dB.Invoices.Count();
            }
        }
        public DataTable Read()
        {
            var select = "SELECT dbo.Invoices.InvoiceNum, dbo.Invoices.Date, dbo.Customer.Name, SUM(dbo.Products.Price) AS [Total] FROM dbo.Invoices INNER JOIN dbo.ProductInvoices ON dbo.Invoices.id = dbo.ProductInvoices.Invoice_id INNER JOIN dbo.Products ON dbo.ProductInvoices.Product_id = dbo.Product.id INNER JOIN dbo.Customers ON dbo.Invoices.Customer_id = dbo.Customers.id GROUP BY dbo.Invoices.InvoiceNum, dbo.Invoices.Date, dbo.Customers.Name ";
            var c = new SqlConnection("Data Source=DESKTOP-NMKICFI\\SQLEXPRESS;Initial Catalog=Rumishop;Integrated Security=true");
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];

        }

        public DataTable Read(string s, int index)
        {
            SqlCommand cmd = new SqlCommand();
            if (index == 0)
            {
                cmd.CommandText = ("dbo.SearchCustomer");

            }
            else if (index == 1)
            {

                cmd.CommandText = ("dbo.SearchCustomerName");

            }
            else if (index == 2)
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
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];

        }

        public DataTable Readp(string s, int index)
        {
            SqlCommand cmd = new SqlCommand();
            if(index == 0)
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