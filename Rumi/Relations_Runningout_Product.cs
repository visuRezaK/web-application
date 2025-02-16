using BE;
using BLL;
using BLL.Relations_BLL;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumi
{
    public partial class Relations_Runningout_Product : UserControl
    {
        Rounningout_Product_BLL rpb= new Rounningout_Product_BLL();
        Product_BLL bLL = new Product_BLL();
        Product_BLL pbll = new Product_BLL();
        Product p = new Product();
        List<Product> Products = new List<Product>();
        List<int> Productid = new List<int>();


        void DVG()
        {
            dataGridView1.DataSource = null;
           // dataGridView1.DataSource = rpb.Read();
            dataGridView1.DataSource = bLL.Read();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["Report"].Visible = false;

        }
        void Clears()
        {
            foreach (System.Windows.Forms.Control control in groupBox1.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    (control as System.Windows.Forms.TextBox).Clear();
                }
            }
        }
        public Relations_Runningout_Product()
        {
            InitializeComponent();
        }
        int id;
        int pid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                Products.Add(pbll.Read(pid));
               // Productid.Add(pid);
                p = pbll.ReadP(pid);
                string s = "Your Product is: " + p.NameProduct +  " and your Barcode is: " + p.Barcode + ", .Stock is: " + p.Stock;
                listBox1.Items.Add(s);


            }
            catch (Exception)
            {

                throw;
            }
            Clears();
            textBox1.Text = "";
        }

        private void Relations_Runningout_Product_Load(object sender, EventArgs e)
        {
            DVG();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        int index;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                index = 0;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pbll.Readp(textBox1.Text, index);
            }
            

            if (textBox1.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pbll.Read();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Clears();
            Products.Clear();
            dataGridView1.Refresh();
            groupBox1.Refresh();
            textBox1.Text = "";
        }

        
    }
}
