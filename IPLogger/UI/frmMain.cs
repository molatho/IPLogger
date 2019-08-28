using IPLogger.Data;
using IPLogger.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPLogger
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Icon = Properties.Resources.ico_iplogger;
            foreach (var target in TargetManager.Targets)
                AddTargetItem(target);
            TargetManager.TargetAdded += TargetManager_TargetAdded;
            TargetManager.TargetRemoved += TargetManager_TargetRemoved;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            TargetManager.TargetAdded -= TargetManager_TargetAdded;
            TargetManager.TargetRemoved -= TargetManager_TargetRemoved;
        }

        private void TargetManager_TargetRemoved(object sender, TargetManager.TargetEventArgs e)
        {
            var targetItem = flowLayoutPanel1.Controls.Cast<TargetItem>().FirstOrDefault(x => x.Target == e.Target);
            if (targetItem != null) flowLayoutPanel1.Controls.Remove(targetItem);
        }

        private void TargetManager_TargetAdded(object sender, TargetManager.TargetEventArgs e)
        {
            AddTargetItem(e.Target);
        }

        private void AddTargetItem(Target target)
        {
            var item = new TargetItem();
            flowLayoutPanel1.Controls.Add(item);
            item.Target = target;
            item.TogglePressed += Item_TogglePressed;
            item.DetailsPressed += Item_DetailsPressed;
            item.DeletePressed += Item_DeletePressed;
            item.Width = flowLayoutPanel1.ClientSize.Width - item.Margin.Left - item.Margin.Right;
        }

        private void Item_DeletePressed(object sender, EventArgs e)
        {
            TargetManager.RemoveTarget(((TargetItem)sender).Target);
        }

        private void Item_DetailsPressed(object sender, EventArgs e)
        {
            var frm = new frmTarget();
            frm.Target = ((TargetItem)sender).Target;
            frm.Show();
        }

        private void Item_TogglePressed(object sender, EventArgs e)
        {
            ((TargetItem)sender).Target.AutoPing = !((TargetItem)sender).Target.AutoPing;
        }

        private void FlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();
            foreach(Control ctrl in flowLayoutPanel1.Controls)
                ctrl.Width = flowLayoutPanel1.ClientSize.Width - ctrl.Margin.Left - ctrl.Margin.Right;
            flowLayoutPanel1.ResumeLayout();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmTargetAdd())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TargetManager.CreateTarget(frm.TargetName, frm.TargetAddress);
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAbout()) frm.ShowDialog();
        }

        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConfig()) frm.ShowDialog();
        }
    }
}
