using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BE;
using BLL.Relations_BLL;
using DevComponents.DotNetBar;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Documents;
using Guna.UI2.AnimatorNS;
using Stimulsoft.Report;
namespace Rumi
{
    public partial class Relations_Invoice : UserControl
    {
        public Relations_Invoice()
        {
            InitializeComponent();
        }
        int pid;
        int cid;
        
        List<Product> Products = new List<Product>();
        List<int> Productid = new List<int>();
        Invoice_BLL ibll = new Invoice_BLL();
        Product_BLL pbll = new Product_BLL();
        Customer_BLL cbll = new Customer_BLL();
        Product p = new Product();
        
        


        void DGV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cbll.Read();
            dataGridView1.Columns["id"].Visible = false;

            dataGridView1.Columns["id"].Visible = false; 
            
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = pbll.Read();
            dataGridView3.DataSource = Products;
            
        }
       
        void Clears()
        {
            foreach (System.Windows.Forms.Control control in groupBox2.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    (control as System.Windows.Forms.TextBox).Clear();
                }
            }
        }
        void Clear()
        {
            foreach (System.Windows.Forms.Control control in groupBox1.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    (control as System.Windows.Forms.TextBox).Clear();
                }
            }
        }
        void clear()
        {
            foreach (System.Windows.Forms.Control control in groupBox3.Controls)
            {
                if (control is System.Windows.Forms.Label)
                {
                    (control as System.Windows.Forms.Label).Controls.Clear();
                }
            }
        }
        private void Relations_Invoice_Load(object sender, EventArgs e)
        {
            
            DGV();
            label10.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");

            AutoCompleteStringCollection NameProduct = new AutoCompleteStringCollection();
            foreach (var item in pbll.ReadNameProduct())
            {
                NameProduct.Add(item);
            }
            AutoCompleteStringCollection barcode = new AutoCompleteStringCollection();
            foreach (var item in pbll.ReadBarcode())
            {
                barcode.Add(item);
            }


            textBox2.AutoCompleteCustomSource = NameProduct;
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Products;
            dataGridView3.Columns["id"].Visible = false;
            dataGridView3.Columns["PurchasePrice"].Visible = false;


        }
                    
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            textBox3.Text = discount.ToString();
            Invoice I = new Invoice();
            Product p = new Product();
            I.SalePrice = Convert.ToDouble(label13.Text);
            I.Discount = Convert.ToDouble(textBox3.Text);
            I.Tax = Convert.ToDouble(label11.Text);
            I.shop = comboBox1.Text;
            I.Total = Convert.ToDouble(label2.Text);
            MessageBox.Show(ibll.Create(I, cid, Productid));
            

           
            Clear();
            clear();
                                          
            dataGridView3.DataSource = null;
            
        }
        int index;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if ((checkBox1.Checked && checkBox2.Checked) || (!checkBox2.Checked && !checkBox1.Checked))
            {
                index = 0;
            }
            else if (checkBox1.Checked) //&& !checkBox2.Checked)
            {
                index = 1;
            }
            else if (checkBox2.Checked)// && !checkBox1.Checked)
            {
                index = 2;
            }
           

            dataGridView1.DataSource = null;
            
            dataGridView1.DataSource = cbll.Read(textBox1.Text, index);
            dataGridView1.Columns["id"].Visible = false;

            if (textBox1.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cbll.Read();
                dataGridView1.Columns["id"].Visible = false;

            }
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
          
            dataGridView3.DataSource = null;
            Products.Clear();
           
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            groupBox3.Refresh();
            textBox3.Text = "";
            label11.Text = "";
            label13.Text = "";
            label6.Text = "";
            label13.Text = "0";
            label2.Text = "0";

            clear();

        }
       
        public double sum = 0;
        public double total = 0;
        public double amount;
        public double discount =0;
        public double sumtax;
        bool applyDiscount = false;

        
        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                index = 0;
                

            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = pbll.Readp(textBox2.Text, index);
           
            if (textBox2.Text == "")
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = pbll.Read();
                
            }

           
            Products.Add(pbll.Read(pid));

            Productid.Add(pid);
                        
            dataGridView3.DataSource = null;

            
            dataGridView3.DataSource = Products;
            
            double sum  = 0;
            foreach (var item in Products.ToList())
            {
                
                sum += (item.SalePrice);
            }
            label13.Text = sum.ToString();
                    
            if (double.TryParse(textBox3.Text, out discount)) 
            {
                
                sum = sum -(discount * sum)/100;
                
            }
           
           
                label11.Text = (sum * 0.13).ToString("N");
               
                sumtax = (sum * 0.13);
          
            // Calculate the total amount
            total = sum + sumtax;
            label2.Text = total.ToString("N");
          
          
           
            Clears();
            clear();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                index = 0;
            }
           
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = pbll.Readp(textBox2.Text, index);
            
            if (textBox2.Text == "")
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = pbll.Read();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
                                           
                 
                   
            
                    
                
                     
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Relations_Invoice i= new Relations_Invoice();

            DialogResult res = MessageBox.Show("Are you want to print?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                StiReport sti= new StiReport();
                sti.Load(@"C:\Users\Admin\Desktop\Invoice.mrt");
                sti.Dictionary.Variables["InvoiceNum"].Value = Convert.ToString(ibll.ReadInvoiceNum());
                sti.Dictionary.Variables["Date"].Value = label10.Text;
                sti.Dictionary.Variables["CustName"].Value = label6.Text;
                sti.Dictionary.Variables["InvoiceDiscount"].Value = textBox3.Text;
                sti.Dictionary.Variables["InvoiceTax"].Value = label11.Text;
                sti.Dictionary.Variables["InvoiceTotal"].Value = label2.Text;
                sti.RegBusinessObject("Product",Products);
                sti.Render();
                sti.Show();
                //sti.Print();
                
                                
            }
        }
           
      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception)
            {

            }

            Customer c = cbll.Read(cid);
            label6.Text = c.Name;
            Clear();
        }

       
       private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

            discount = 0;
            double sum = 0;
            foreach (var item in Products)
            {
                sum += (item.SalePrice);
            }
            label13.Text = sum.ToString();
            if (double.TryParse(textBox3.Text, out discount))
            {

                sum = sum - (discount * sum) / 100;


            }
            {
                label11.Text = (sum * 0.13).ToString("N");
                //textBox3.Text = (sum * 0.13).ToString();
                sumtax = (sum * 0.13);
            }
            total = sum + sumtax;
            label2.Text = total.ToString("N");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["id"].Value.ToString());
            
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Products.ToList();
            dataGridView3.Columns["PurchasePrice"].Visible = false;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

       
    }
}