using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPLogger.Data;

namespace IPLogger.UI
{
    public partial class TargetItem : UserControl
    {
        public Target Target
        {
            get { return target; }
            set
            {
                if (target != null)
                {
                    target.DataPointAdded -= Target_DataPointAdded;
                    target.AutoPingChanged -= Target_AutoPingChanged;
                }
                target = value;

                if (target != null)
                {
                    target.DataPointAdded += Target_DataPointAdded;
                    target.AutoPingChanged += Target_AutoPingChanged;
                    UpdateStats();
                }
            }
        }

        public event EventHandler DeletePressed;
        public event EventHandler TogglePressed;
        public event EventHandler DetailsPressed;

        private void Target_AutoPingChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                UpdateStats();
            });
        }

        private void Target_DataPointAdded(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                UpdateStats();
            });
        }

        private Target target;

        public TargetItem()
        {
            InitializeComponent();
        }

        private void UpdateStats()
        {
            var entry = Target.GetAll().OrderByDescending(x => x.TimeStamp).FirstOrDefault();
            tgtName.Text = target.ToString();
            tgtToggle.Image = target.AutoPing
                ? Properties.Resources.ico_stop
                : Properties.Resources.ico_start;

            if (entry == null)
                tgtStatus.Text = "Status: -";
            else
                tgtStatus.Text = $"Status: {entry}";

            if (!target.DataPoints.Any())
            {
                tgtUptime.Text = $"Uptime 24h: -";
                tgtDown.Text = $"Downtimes: -";
                tgtImage.BackColor = Color.Gray;
                tgtImage.Height = 64;
            }
            else
            {
                var downtime24 = target.GetDownTimes(target.GetLastDay());
                TimeSpan totalDowntime = TimeSpan.Zero;
                foreach (var dt in downtime24) totalDowntime += dt.Duration;
                var uptime24h = target.Uptime24h;
                tgtUptime.Text = $"Uptime 24h: {(uptime24h * 100).ToString("0.00")}%";
                if (totalDowntime == TimeSpan.Zero)
                    tgtDown.Text = $"Downtimes 24h: {downtime24.Length}";
                else
                    tgtDown.Text = $"Downtimes 24h: {downtime24.Length} ({totalDowntime.ToString(@"dd\.hh\:mm\:ss")})";
                tgtImage.BackColor = Lerp(Color.Red, Color.Orange, Color.Green, uptime24h);
                tgtImage.Height = (int)(64 * uptime24h);
            }
        }

        private Color Lerp(Color a, Color b, Color c, float t)
        {
            if (t < 0.5f) return Lerp(a, b, t * 2f);
            return Lerp(b, c, (t - 0.5f) * 2f);
        }
        private Color Lerp(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        private void TgtToggle_Click(object sender, EventArgs e)
        {
            TogglePressed?.Invoke(this, EventArgs.Empty);
        }

        private void TgtDelete_Click(object sender, EventArgs e)
        {
            DeletePressed?.Invoke(this, EventArgs.Empty);
        }

        private void TgtDetails_Click(object sender, EventArgs e)
        {
            DetailsPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
