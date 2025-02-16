using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumi
{
    public partial class MainForm : Form
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

        public MainForm()
        {
            InitializeComponent();
        }
        public string loginformusername;
       
                           
        private void button1_Click(object sender, EventArgs e)
        {
            Relations_Product product = new Relations_Product();
            panel2.Controls.Clear();
            panel2.Controls.Add(product);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relations_Customer i = new Relations_Customer();
            panel2.Controls.Clear();
            panel2.Controls.Add(i);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Relations_Invoice i = new Relations_Invoice();
            panel2.Controls.Clear();
            panel2.Controls.Add(i);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Relations_Report r= new Relations_Report();
            panel2.Controls.Clear();
            panel2.Controls.Add(r);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Relations_User_Picture u = new Relations_User_Picture();
            panel2.Controls.Clear();
            panel2.Controls.Add(u);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Backup_Restore b = new Backup_Restore();
            panel2.Controls.Clear();
            panel2.Controls.Add(b);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult Exit = MessageBox.Show("Do you want to exit?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Exit == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        public void ClearPanel()
        {
            panel2.Controls.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Relations_Runningout_Product o= new Relations_Runningout_Product();
            panel2.Controls.Clear();
            panel2.Controls.Add(o);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClearPanel();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Relations_Password password= new Relations_Password();
            panel2.Controls.Clear();
            panel2.Controls.Add(password);
        }

        private void button7_Click(object sender, EventArgs e)
        {
          LoginForm f= new LoginForm();
            panel2.Controls.Clear();
            f.ShowDialog(this);
            Close();
            
        }
    }
}
