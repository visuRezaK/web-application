using System;
using System.Windows.Forms;
using FoxLearn.License;
using BE;
using BLL;
using System.Runtime.InteropServices;
using DeviceId;

namespace Rumi
{
    public partial class RegisterAdmin : Form
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
        public RegisterAdmin()
        {
            InitializeComponent();
        }

        Login_User_BLL bll= new Login_User_BLL();

        private void RegisterAdmin_Load(object sender, EventArgs e)
        {
            textBox1.Text = ComputerInfo.GetComputerId();


            //textBox1.Text = new DeviceIdBuilder()
              // .AddMachineName()
              // .AddMacAddress()
              // .ToString();

        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(textBox1.Text);
            string productKey = textBox2.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }
                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("Program activation was done successfully!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("License code is not valide!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == textBox6.Text)
            {
                bll.Register(new User_Login() { Name = textBox3.Text, UserName = textBox4.Text ,Password = textBox5.Text,Repassword = textBox6.Text });
                MessageBox.Show("Admin account was created", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((LoginForm)Application.OpenForms["LoginForm"]).label2.Visible = false;
                this.Close();
            }
        }

        private void RegisterAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

      
    }
}
