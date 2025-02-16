using Azure.Identity;
using BE;
using BLL;
using DevComponents.DotNetBar.Controls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumi
{
    public partial class Relations_Password : UserControl
    {
        public Relations_Password()
        {
            InitializeComponent();
        }

        bool flag;
        //User_Picture_BLL bLL = new User_Picture_BLL();
        User_Login bll = new User_Login();
        Login_User_BLL bLL= new Login_User_BLL();
        Change_Password_BLL BLL= new Change_Password_BLL();
        

        void DVG()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bLL.Read();
            dataGridView1.Columns["Pic"].Visible = false;
            dataGridView1.Columns["Status"].Visible = false;
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
        private void Relations_Password_Load(object sender, EventArgs e)
        {

            DVG();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }
        int id;
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
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

                
           User_Login u=bLL.Read(id);
            
            textBox1.Text = u.Name;
            textBox2.Text = u.UserName;
            textBox4.Text = u.Password;
            textBox6.Text = u.Repassword;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var a = groupBox1.Controls.OfType<TextBoxX>().Any(i => i.Text == "");
            if (a)
            {
                MessageBox.Show("Please complete all information first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                User_Login u = new User_Login();
                u.Name = textBox1.Text;
                u.UserName = textBox2.Text;
                //u.RegDate = DateTime.Now;
                u.Password = textBox4.Text; 
                u.Repassword = textBox6.Text;


                //if(textBox4.Text == textBox6.Text)
                if (u.Password.Length >= 6 && u.Repassword.Length >= 6 && u.Password == u.Repassword)
                {
                    u.Password = textBox6.Text;
                   
                    {
                        MessageBox.Show(BLL.Update(id, u));
                   
                    }
                     
                    
                }
                else 
                {

                    MessageBox.Show("your Password is wrong! please try again");
                }
               
               // dataGridView1.DataSource = null;
               // dataGridView1.DataSource = bLL.Read(u);
               
                DVG();
                Clears();
            }

            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

       
    }
}
