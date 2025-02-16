using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using BLL.Relations_BLL;
using Guna.UI2.WinForms;
using Microsoft.SqlServer.Management.Smo;
using Stimulsoft.Report;

namespace Rumi
{
    public partial class Relations_Report : UserControl
    {
        
       Report_BLL bll = new Report_BLL();
        
        public Relations_Report()
        {
            InitializeComponent();
        }

        int id;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Relations_Invoice i = new Relations_Invoice();
                DialogResult res = MessageBox.Show("Are you want to print?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    StiReport sti = new StiReport();
                    sti.Load(@"C:\Users\Admin\Desktop\InvoiceReport.mrt");
                    sti.Render();
                    sti.Show();
                    //sti.Print();
                }
            }
            if (radioButton2.Checked)
            {
                Relations_Invoice i = new Relations_Invoice();
                DialogResult res = MessageBox.Show("Are you want to print?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    StiReport sti = new StiReport();
                    sti.Load(@"C:\Users\Admin\Desktop\CustomerProduct.mrt");
                    sti.Render();
                    sti.Show();
                    //sti.Print();
                }
            }

            if (radioButton3.Checked)
            {
                Relations_Invoice i = new Relations_Invoice();
                DialogResult res = MessageBox.Show("Are you want to print?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    StiReport sti = new StiReport();
                    sti.Load(@"C:\Users\Admin\Desktop\InvoiceCustomer.mrt");
                    sti.Render();
                    sti.Show();
                    //sti.Print();
                }
            }
            if (radioButton4.Checked)
            {
                Relations_Invoice i = new Relations_Invoice();
                DialogResult res = MessageBox.Show("Are you want to print?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    StiReport sti = new StiReport();
                    sti.Load(@"C:\Users\Admin\Desktop\ProductInvoice.mrt");
                    sti.Render();
                    sti.Show();
                    //sti.Print();
                }
            }

        }

       
        private void label5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        
        int index;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                index = 0;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read(textBox1.Text, index);
            if(textBox1.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bll.Read();
                
            }
        }

        private void Relations_Report_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
