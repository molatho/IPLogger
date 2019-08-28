using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLogger.UI
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            Icon = Properties.Resources.ico_iplogger;
            var assembly = Assembly.GetExecutingAssembly();
            lblVersion.Text = assembly.GetName().Version.ToString();
            lblFolder.Text = new FileInfo(assembly.Location).Directory.FullName;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.xing.com/profile/Moritz_Thomas12");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/moritz-thomas-34992718a/");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/molatho");
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.flaticon.com/authors/smashicons");
        }
    }
}
