using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using DevComponents.DotNetBar.Controls;
using Guna.UI2.AnimatorNS;

namespace Rumi
{
    public partial class Relations_User_Picture : UserControl
    {
        public Relations_User_Picture()
        {
            InitializeComponent();
        }
        
        User_Picture_BLL BLL = new User_Picture_BLL();
        Login_User_BLL bLL = new Login_User_BLL();
        Image Pic;
        OpenFileDialog f = new OpenFileDialog();
        User_Login u = new User_Login();

        bool flag = true;
        int id;

        void SetDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bLL.Read();
            dataGridView1.Columns["id"].Visible = false;
            
            dataGridView1.Columns["Pic"].Visible = false;
            dataGridView1.Columns["Status"].Visible = false;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            
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
        
        private void Relations_User_Load(object sender, EventArgs e)
        {
            SetDataGrid();
        }

       
                
              
      private void guna2Button2_Click(object sender, EventArgs e)
        {



            var a = groupBox1.Controls.OfType<TextBoxX>().Any(i => i.Text == "");
            if (a)
            {
                MessageBox.Show("Please complete all information first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                bLL.Register(new User_Login() { Name = textBox1.Text, UserName = textBox4.Text, Password = textBox5.Text, Repassword = textBox6.Text });
                if (!flag)
                {
                    
                    MessageBox.Show("Registeration user is done");
                }
                else if(flag)
                {
                    MessageBox.Show("Lenght password must be more than 8 carachters!");
                }


                               
                
                SetDataGrid();
                
                Clears();
            }


         
   

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
               {
                    id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
                catch (Exception)
                {

                }
            SetDataGrid();
        }

       
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure,you want delete the user!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BLL.Delete(id);
            }
            SetDataGrid();
        }

        //private void guna2Button3_Click(object sender, EventArgs e)
        //{
        //    Clears();
        //    flag = true;
        //    guna2Button2.Text = "User register";
        //}

        private void label5_Click(object sender, EventArgs e)
        {
            this.Visible= false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
