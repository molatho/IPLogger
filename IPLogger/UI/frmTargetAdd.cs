using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLogger.UI
{
    public partial class frmTargetAdd : Form
    {
        public string TargetName { get => targetName.Text; set => targetName.Text = value; }
        public IPAddress TargetAddress { get; private set; }


        public frmTargetAdd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Icon = Properties.Resources.ico_iplogger;
        }

        private void TxbIP_TextChanged(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(targetIp.Text, out IPAddress address))
                TargetAddress = address;
            else
                TargetAddress = null;
            UpdateOkay();
        }

        private void TxbName_TextChanged(object sender, EventArgs e)
        {
            UpdateOkay();
        }

        private void UpdateOkay()
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(TargetName) && TargetAddress != null;
        }

        private void HostName_TextChanged(object sender, EventArgs e)
        {
            hostResolve.Enabled = hostName.TextLength > 0;
        }

        private void HostResolve_Click(object sender, EventArgs e)
        {
            try
            {
                var addresses = Dns.GetHostAddresses(hostName.Text);
                hostList.DataSource = addresses;
            }
            catch (Exception ex)
            {
                hostList.DataSource = new string[]
                {
                    $"Failed: {ex.GetType().Name}"
                };
            }
        }

        private void HostList_MouseClick(object sender, MouseEventArgs e)
        {
            var address = hostList.SelectedItem as IPAddress;
            if (address == null) return;
            targetIp.Text = address.ToString();
            if (targetName.TextLength == 0 && hostName.TextLength > 0)
                targetName.Text = hostName.Text;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
