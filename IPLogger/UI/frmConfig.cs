using IPLogger.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLogger.UI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Icon = Properties.Resources.ico_iplogger;
            cfgAutoStartSystem.Checked = Config.AutoStartSystem;
            cfgAutoStartPinging.Checked = Config.AutoStartPinging;
            cfgPingInterval.Value = Config.PingIntervals;
            cfgPingTimeout.Value = Config.PingTimeout;
        }

        private void CfgAutoStartSystem_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoStartSystem = cfgAutoStartSystem.Checked;
        }

        private void CfgAutoStartPinging_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoStartPinging = cfgAutoStartPinging.Checked;
        }

        private void CfgPingInterval_ValueChanged(object sender, EventArgs e)
        {
            Config.PingIntervals = (int)cfgPingInterval.Value;
        }

        private void CfgPingTimeout_ValueChanged(object sender, EventArgs e)
        {
            Config.PingTimeout = (int)cfgPingTimeout.Value;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
