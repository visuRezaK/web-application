using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;


namespace DAL.Relations_DAL
{
    public class Product_DAL
    {
        DB_Support db = new DB_Support();
        public string Create(Product p)
        {
            if (!Read(p))
            {
                if(p.Barcode.Length > 6) 
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                    return "Registration information completed successfully";
                }
                else
                {
                    return "Barcode is Not Valide";
                }
            }
            else
            {
                return "The entered information is duplicated";
            }
        }
        public bool Read(Product p)
        {
            return db.Products.Any(i => i.NameProduct == p.NameProduct || i.Barcode == p.Barcode);
        }
        public Product ReadP(int id)
        {
            return db.Products.Find(id);
        }
        public List<Product> Read()
        {
            return db.Products.ToList();
        }
        public List<string> ReadNameProduct()
        {
            return db.Products.Select(i => i.NameProduct).ToList();
        }
        public List<string> ReadBarcode()
        {
            return db.Products.Select(i => i.Barcode).ToList();
        }

        public int FindId(string name)
        {
                       
         return db.Products.FirstOrDefault(p => p.NameProduct == name || p.Barcode == name).id;
                     
       }
       
        public Product Read(int id)
        {
            return db.Products.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(int id , Product pnew)
        {
            Product p= new Product();
            p = Read(id);
            p.NameProduct = pnew.NameProduct;
            p.Barcode = pnew.Barcode;
            p.PurchasePrice = pnew.PurchasePrice;
            p.SalePrice = pnew.SalePrice;
            p.Stock = pnew.Stock;
            p.Color = pnew.Color;
            
            p.Size = pnew.Size;

            db.SaveChanges();
            return "Update information has completed successfully";
        }
        public string Delete(int id)
        {
            Product p=Read(id);
            db.Products.Remove(p);
            db.SaveChanges();
            return "Delete information has completed successfully";
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
