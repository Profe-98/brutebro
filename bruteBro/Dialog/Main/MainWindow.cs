using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using bruteBro.Class;
using bruteBro.Class.Network;
using bruteBro.Dialog.Secondary;

namespace bruteBro
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(TBOX_ip.Text))
            {
                IPAddress ipAddr = null;
                if (IPAddress.TryParse(TBOX_ip.Text, out ipAddr))
                {
                    //ObjectManager.BruteForce();
                }
            }


        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //this.HelpButton = true;
            LogText("Starting Program....");
            LogText("Load avaible Protocols....");
        }

        private void LogText(string msg)
        {
            msg = "["+DateTime.Now.ToString("yyyy-MM-dd")+"] [" + DateTime.Now.ToString("HH:mm:ss") + "]:" + msg + Environment.NewLine;
            TBOX_log.Text += msg;
        }

        private void LogonTryCHBOX_CheckedChanged(object sender, EventArgs e)
        {
            if(CHBOX_logonTry.Checked == true)
            {
                LogText("Testing logon trys before bruteforce");
            }
            else
            {
                LogText("Not testing logon trys before bruteforce");
            }
        }

        private void PasswordLenghtTBAR_Scroll(object sender, EventArgs e)
        {
            TBARLAB_pwlength.Text = "PasswordLength - " + TBAR_passwordLenght.Value;
        }

        private void PasswordLenghtTBAR_MouseUp(object sender, MouseEventArgs e)
        {

            LogText("Passwordlenght updated to a lenght of " + TBAR_passwordLenght.Value + "");
        }

        private void BTN_rainbowtbls_Click(object sender, EventArgs e)
        {
            List<string> tbls = FileManager.OpenFiles();
            foreach (string tbl in tbls)
            {
                LogText($"Added rainbow table {tbl}");
                LB_rainbow_files.Items.Add(tbl);
            }
        }

        private void BTN_Start1_Click(object sender, EventArgs e)
        {

        }
    }
}
