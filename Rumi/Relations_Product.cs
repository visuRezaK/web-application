using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL.Relations_BLL;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using Microsoft.SqlServer.Management.Smo;



namespace Rumi
{
    public partial class Relations_Product : UserControl
    {
        public Relations_Product()
        {
            InitializeComponent();
        }
        Product_BLL pbll = new Product_BLL();
        Product_BLL bLL = new Product_BLL();
        List<Product> Products = new List<Product>();
        bool flag = true;
        int id;

        void DGV()
        {
            dataGridView1.DataSource = null;
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
       

        private void Relations_Product_Load(object sender, EventArgs e)
        {
            DGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.NameProduct = textBox1.Text;
            p.SalePrice = (float)Convert.ToDouble(textBox2.Text);
            p.PurchasePrice =(float)Convert.ToDouble(textBox3.Text);
            p.Barcode = textBox4.Text;
            p.Category = comboBox1.Text;
            p.Stock = Convert.ToInt32(textBox5.Text);
            p.Color = textBox7.Text;
            p.Size = textBox6.Text;
            p.RegDate = DateTime.Now;
            

            if (flag)
            {
                //Create
                MessageBox.Show(bLL.Create(p));
            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(bLL.Update(id, p));
                flag = true;
                button1.Text = "Product register";

            }
            DGV();
            Clears();
        }

        
        private void UpdatetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product p = bLL.Read(id);

            textBox1.Text = p.NameProduct;
            textBox2.Text = p.SalePrice.ToString();
            textBox3.Text = p.PurchasePrice.ToString();
            textBox4.Text = p.Barcode;
            textBox5.Text = p.Stock.ToString();
            textBox6.Text = p.Size;
            textBox7.Text = p.Color;
            comboBox1.Text = p.Category.ToString();

            flag = false;
            button1.Text = "update product";
        }

        private void deletetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure,you want delete the product!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                    bLL.Delete(id);
            }
            
            DGV();
        }
        int index;
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
          
            if (textBox8.Text != "")
            {
                index = 0;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pbll.Readp(textBox8.Text, index);
          
            if (textBox8.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pbll.Read();
            }
           

            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                //dataGridView1.Columns["Report"].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
            Clears();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Clears();
            flag = true;
            button1.Text = "Product register";
            Products.Clear();
            dataGridView1.Refresh();
            groupBox1.Refresh();
            textBox8.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        
                        
    }
}
