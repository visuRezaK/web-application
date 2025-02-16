using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL.Relations_BLL;

namespace Rumi
{
    public partial class Relations_Customer : UserControl
    {
        public Relations_Customer()
        {
            InitializeComponent();
        }
        Customer_BLL bLL = new Customer_BLL();
        bool flag = true;
        int id;

        void DGV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bLL.Read();
            //dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 180;
            //guna2DataGridView1.DataSource = null;
            //guna2DataGridView1.DataSource = bLL.Read();
            
        }

        private void Relations_Customer_Load(object sender, EventArgs e)
        {
            DGV();
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
                      
        private void button1_Click(object sender, EventArgs e)
            {
            Customer c= new Customer();
            c.Name = textBox1.Text;
            c.Phone = textBox2.Text;
            c.email = textBox3.Text;
            c.RegDate= DateTime.Now;
            
            if(flag)
            {
                //Create
                MessageBox.Show(bLL.Create(c));
            }
            else if(!flag) 
            {
                //Update
                MessageBox.Show(bLL.Update(id, c));
                flag = true;
                button1.Text = "New customer register";
               
            }
            DGV();
            Clears();

        }

        
        private void customerupdatetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer c = bLL.Read(id);

            textBox1.Text = c.Name;
            textBox2.Text = c.Phone;
            textBox3.Text = c.email;


            flag = false;
            button1.Text = "update customer";
            
        }
        
        private void customerdeletetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure,you want delete the customer!","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bLL.Delete(id);
            }
           
            DGV();
        }
        int index;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((checkBox1.Checked && checkBox2.Checked) || (!checkBox2.Checked && !checkBox1.Checked))
            {
               index= 0;
            }
            else if(checkBox1.Checked) //&& !checkBox2.Checked)
            {
                index = 1;
            }
            else if(checkBox2.Checked)// && !checkBox1.Checked)
            {
                index = 2;
            }
             //guna2DataGridView1.DataSource = null;
            // guna2DataGridView1 .DataSource = bLL.Read(textBox4.Text,index);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bLL.Read(textBox4.Text, index);
           
           
            if (textBox4.Text == "")
            {
                
                DGV();
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Clears();
            flag = true;
            button1.Text = "Customer register";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
