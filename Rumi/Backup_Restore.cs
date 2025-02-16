using DevComponents.DotNetBar.Controls;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace Rumi
{
    public partial class Backup_Restore : UserControl
    {
        public Backup_Restore()
        {
            InitializeComponent();
        }

        #region Connection Strings
        private string BackUpConString = (@"Data Source=DESKTOP-NMKICFI\\SQLEXPRESS;Initial Catalog=Rumishop;Integrated Security=true;"); // کانکشن استرینگ برای دسترسی به دیتابیس اصلی
        private string ReStoreConString = (@"Data Source=DESKTOP-NMKICFI\\SQLEXPRESS;Initial Catalog=Rumishop;Integrated Security=true;"); // کانکشن استرینگ برای دسترسی به دیتابیس مستر
        #endregion

        #region Backup
        private void Backup_Restore_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          //  circularProgress1.Visible = true;
          //  circularProgress1.Start();

            using (SqlConnection con = new SqlConnection(BackUpConString))
            {
                ServerConnection srvConn = new ServerConnection();
                Server srvr = new Server(srvConn);

                if (srvr != null)
                {
                    try
                    {
                        Backup bkpDatabase = new Backup();
                        bkpDatabase.Action = BackupActionType.Database;
                        bkpDatabase.Database = ("Data Source=DESKTOP-NMKICFI\\SQLEXPRESS;Initial Catalog=Rumishop;Integrated Security=true;"); // باید هم نام با دیتابیس برنامه تنظیم شود
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "BackUp File|*.araDB";
                        sfd.FileName = "BackUp_" + (DateTime.Now.ToShortDateString().Replace('/', '.'));
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            BackupDeviceItem bkpDevice = new BackupDeviceItem(sfd.FileName, DeviceType.File);
                            bkpDatabase.Devices.Add(bkpDevice);
                            bkpDatabase.SqlBackup(srvr);
                            System.Windows.Forms.MessageBox.Show("!Backup file save successfully", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ) { System.Windows.Forms.MessageBox.Show("!Please save backup file to another drive", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

           // circularProgress1.Stop();
          //  circularProgress1.Visible = false;
        }
        #endregion

        #region Restore
        private void guna2Button2_Click(object sender, EventArgs e)
        {

          //  circularProgress1.Visible = true;
          //  circularProgress1.Start();

            if (System.Windows.Forms.MessageBox.Show("!!!ممکن است تمام اطلاعات حال حاظر بانک اطلاعاتی شما تغییر کند \n !اگر مشکلی با این مورد ندارید بله را انتخاب کنید", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection.ClearAllPools();
                using (SqlConnection con = new SqlConnection(ReStoreConString))
                {
                    ServerConnection srvConn = new ServerConnection();
                    Server srvr = new Server(srvConn);

                    srvr.KillAllProcesses("ToseGar");
                    if (srvr != null)
                    {
                        try
                        {
                            Restore rstDatabase = new Restore();
                            rstDatabase.Action = RestoreActionType.Database;
                            rstDatabase.Database = "ToseGar"; // باید هم نام با دیتابیس برنامه تنظیم شود
                            OpenFileDialog opfd = new OpenFileDialog();
                            opfd.Filter = "BackUp File|*.araDB";

                            if (opfd.ShowDialog() == DialogResult.OK)
                            {
                                BackupDeviceItem bkpDevice = new BackupDeviceItem(opfd.FileName, DeviceType.File);
                                rstDatabase.Devices.Add(bkpDevice);

                                rstDatabase.ReplaceDatabase = true;
                                rstDatabase.SqlRestore(srvr);
                                System.Windows.Forms.MessageBox.Show("!اطلاعات با موفقیت بازیابی شد", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception f)
                        {
                            System.Windows.Forms.MessageBox.Show(f.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

         //   circularProgress1.Stop();
         //   circularProgress1.Visible = false;
        }

        #endregion

        private void label5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }

}







