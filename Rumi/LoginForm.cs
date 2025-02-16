using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using BLL;
using Azure.Identity;
using BE;



namespace Rumi
{
    public partial class LoginForm : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        void Move()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        Login_User_BLL bll = new Login_User_BLL();
        RegisterAdmin r = new RegisterAdmin();
       

        MainForm m = new MainForm();
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //User_Picture u = new User_Picture();
            //u.Username = textBox1.Text;
            //u.Password = textBox2.Text;
            //u.Repassword = textBox3.Text;   
            if (bll.Login("", "","") == 0 )
            {
                label2.Visible = true;
            }
            textBox1.Text = Properties.Settings.Default.username;
            if (textBox1.Text == "")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
           
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            textBox1.WordWrap = true;
        }

       
        private void label2_Click(object sender, EventArgs e)
        {
            r.ShowDialog();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (bll.Login(textBox1.Text, textBox2.Text,textBox3.Text) == 1)
            {
                m.loginformusername = "(: Welcome " + textBox1.Text;
                label1.Text = "Welcome!";
                m.Show();
                this.Hide();
            }
            else if (bll.Login("", "","") == 0)
            {
                label1.Text = "برنامه هنوز فعال سازی نشده است!";
            }
            else
            {
                label1.Text = "username or password is wrong!";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.username = textBox1.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.Save();
            }
           
           
            
            //if(bll.Login(textBox1.Text,textBox2.Text) == 1)
            //{
            //    u.Username = textBox1.Text;
            //    u.Password = textBox2.Text;
            //}
            //m.Show();
            //this.Hide();
            
                
            

        }

      
    }    
       
}
