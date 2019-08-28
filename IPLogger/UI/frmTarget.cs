using IPLogger.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLogger.UI
{
    public partial class frmTarget : Form
    {
        public Target Target
        {
            get { return target; }
            set
            {
                if (target != value)
                {
                    if (target != null) target.DataPointAdded -= OnTargetDataPointAdded;
                    target = value;
                    graph1.Provider = target;
                    if (target != null)
                    {
                        target.DataPointAdded += OnTargetDataPointAdded;
                        OnTargetDataPointAdded(target, EventArgs.Empty);
                    }
                }
            }
        }
        private Target target;

        public frmTarget()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Icon = Properties.Resources.ico_iplogger;
            grphMode.DataSource = new Graph.eGraphMode[] { Graph.eGraphMode.Latest, Graph.eGraphMode.Between };
            grphMode.SelectedItem = Graph.eGraphMode.Latest;
            graph1.GraphModeLatest = TimeSpan.FromMinutes(5);
            graph1.GraphModeFrom = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            graph1.GraphModeTo = DateTime.Now;
            grphLatestTimespan.Text = graph1.GraphModeLatest.ToString(@"dd\.hh\:mm\:ss");
            grphBetweenStart.Value = graph1.GraphModeFrom;
            grphBetweenEnd.Value = graph1.GraphModeTo;
        }

        private void OnTargetDataPointAdded(object sender, EventArgs e)
        {
            if (InvokeRequired)
                this.Invoke((MethodInvoker)delegate { UpdateUI(); });
            else
                UpdateUI();
        }

        private void UpdateUI()
        {
            Text = infName.Text = target == null
                ? "-"
                : target.Name;
            infFile.Text = target == null
                ? "-"
                : target.File.Name;
            infAddress.Text = target == null
                ? "-"
                : target.Address.ToString();

            var latest = target?.LatestDataPoint;
            infStatus.Text = latest == null
                ? "-"
                : latest.ToString();
            infUptime.Text = target == null || !target.DataPoints.Any()
                ? "-"
                : $"{(target.Uptime24h * 100).ToString("0.00")}% / {(target.UptimeAll * 100).ToString("0.00")}%";
            infDowntimes.Text = target == null || !target.DataPoints.Any()
                ? "-"
                : $"{target.Downtimes24h} / {target.DowntimesAll}";

            var downtimes24h = Target.GetDownTimes(Target.GetLastDay());
            var downtimesAll = Target.GetDownTimes(Target.GetAll());
            UpdateDowntimeList(dwn24h, downtimes24h);
            UpdateDowntimeList(dwnAll, downtimesAll);
        }

        private void UpdateDowntimeList(ListView ltv, Downtime[] downtimes)
        {
            var items = ltv.Items.Cast<ListViewItem>();
            foreach (var dt in downtimes)
            {
                var item = items.FirstOrDefault(x => ((Downtime)x.Tag).From == dt.From);
                if (item == null)
                {
                    item = new ListViewItem(dt.ToString());
                    item.Tag = dt;
                    ltv.Items.Add(item);
                }
                else
                {
                    item.Text = dt.ToString();
                }
            }
        }

        private void Graph1_HasDrawn(object sender, EventArgs e)
        {
            grphFromLbl.Text = $"{graph1.ViewFrom.ToShortDateString()} {graph1.ViewFrom.ToLongTimeString()}";
            grphToLbl.Text = $"{graph1.ViewTo.ToShortDateString()} {graph1.ViewTo.ToLongTimeString()}";
            var diff = graph1.ViewTo - graph1.ViewFrom;
            var mid = graph1.ViewFrom + (TimeSpan.FromSeconds(diff.TotalSeconds * 0.5f));
            grphNowLbl.Text = $"{mid.ToShortDateString()} {mid.ToLongTimeString()}";
            grphLatestTimespan.Text = graph1.GraphModeLatest.ToString(@"dd\.hh\:mm\:ss");
        }

        private Graph.eGraphMode CurrentMode
        {
            get { return graph1.GraphMode; }
            set
            {
                if (graph1.GraphMode != value)
                {
                    graph1.GraphMode = value;
                    grphMode.SelectedItem = value;
                    AdjustBetweenScroll();
                }
            }
        }

        private void AdjustBetweenScroll()
        {
            if (CurrentMode == Graph.eGraphMode.Between)
            {
                var first = target.DataPoints.First();
                var last = target.DataPoints.Last();
                var duration = last.TimeStamp - first.TimeStamp;
                grphScroll.Maximum = (int)(duration.TotalSeconds - graph1.GraphModeLatest.TotalSeconds);
                grphScroll.Value = Math.Min(grphScroll.Maximum, Math.Max(0, (int)((graph1.GraphModeFrom - first.TimeStamp).TotalSeconds)));
            }
        }

        private void GrphMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(grphMode.SelectedItem is Graph.eGraphMode)) return;
            var mode = (Graph.eGraphMode)grphMode.SelectedItem;
            CurrentMode = mode;
            graph1.GraphMode = mode;
            grphBetweenEnd.Enabled = grphBetweenStart.Enabled = mode == Graph.eGraphMode.Between;
            grphScroll.Visible = mode == Graph.eGraphMode.Between;
        }

        private void GrphLatestTimespan_TextChanged(object sender, EventArgs e)
        {
            TimeSpan duration;
            if (TimeSpan.TryParseExact(grphLatestTimespan.Text, @"dd\.hh\:mm\:ss", CultureInfo.InvariantCulture, out duration))
            {
                graph1.GraphModeLatest = duration;
                AdjustBetweenWindow(graph1.GraphModeFrom, graph1.GraphModeFrom + graph1.GraphModeLatest);
            }
        }

        private void AdjustBetweenWindow(DateTime from, DateTime to)
        {
            graph1.GraphModeFrom = from;
            graph1.GraphModeTo = to;
            grphBetweenStart.Value = from;
            grphBetweenEnd.Value = to;
            graph1.GraphModeLatest = to - from;
            AdjustBetweenScroll();
        }

        private void GrphBetweenStart_ValueChanged(object sender, EventArgs e)
        {
            AdjustBetweenWindow(grphBetweenStart.Value, graph1.GraphModeTo);
        }

        private void GrphBetweenEnd_ValueChanged(object sender, EventArgs e)
        {
            AdjustBetweenWindow(graph1.GraphModeFrom, grphBetweenEnd.Value);
        }

        private void GrphScroll_Scroll(object sender, ScrollEventArgs e)
        {
            var min = target.DataPoints.First().TimeStamp;
            var from = min + TimeSpan.FromSeconds(grphScroll.Value);
            var to = from + graph1.GraphModeLatest;
            AdjustBetweenWindow(from, to);
        }

        private void Dwn24h_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = dwn24h.SelectedItems.Count > 0 ? dwn24h.SelectedItems[0].Tag as Downtime : null;
            if (item != null)
            {
                CurrentMode = Graph.eGraphMode.Between;
                AdjustBetweenWindow(item.From - TimeSpan.FromMinutes(5),
                    item.To + TimeSpan.FromMinutes(5));
            }
        }

        private void DwnAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = dwnAll.SelectedItems.Count > 0 ? dwnAll.SelectedItems[0].Tag as Downtime : null;
            if (item != null)
            {
                CurrentMode = Graph.eGraphMode.Between;
                AdjustBetweenWindow(item.From - TimeSpan.FromMinutes(5),
                    item.To + TimeSpan.FromMinutes(5));
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AdjustBetweenWindow(graph1.GraphModeFrom, graph1.GraphModeFrom + graph1.GraphModeLatest.Add(TimeSpan.FromMinutes(1)));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AdjustBetweenWindow(graph1.GraphModeFrom, graph1.GraphModeFrom + graph1.GraphModeLatest.Add(TimeSpan.FromMinutes(10)));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AdjustBetweenWindow(graph1.GraphModeFrom, graph1.GraphModeFrom + graph1.GraphModeLatest.Add(TimeSpan.FromHours(1)));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AdjustBetweenWindow(graph1.GraphModeFrom, graph1.GraphModeFrom + graph1.GraphModeLatest.Add(TimeSpan.FromDays(1)));
        }
    }
}
