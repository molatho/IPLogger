using IPLogger.Data;
using IPLogger.UI;
using IPLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLogger
{
    static class Program
    {
        private static Thread pingThread;
        private static NotifyIcon icon;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config.Initialize();
            TargetManager.Initialize();

            pingThread = new Thread(PingAll);
            pingThread.Start();
            BuildTrayIcon();

            new frmMain().Show();
            Application.Run();
            icon.Dispose();
            pingThread.Abort();
            TargetManager.DisposeAll();
        }

        private static void BuildTrayIcon()
        {
            icon = new NotifyIcon()
            {
                Icon = Properties.Resources.ico_iplogger,
                Text = "IPLogger",
                Visible = true
            };
            icon.ContextMenuStrip = new ContextMenuStrip();
            var show = icon.ContextMenuStrip.Items.Add("Open");
            show.Click += (o, e) => new frmMain().Show();

            var config = icon.ContextMenuStrip.Items.Add("Configuration");
            config.Click += (o, e) => new frmConfig().Show();
            config.Image = Properties.Resources.ico_settings;

            var about = icon.ContextMenuStrip.Items.Add("About");
            about.Click += (o, e) => new frmAbout().ShowDialog();
            about.Image = Properties.Resources.ico_info;

            icon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            var exit = icon.ContextMenuStrip.Items.Add("Exit");
            exit.Click += (o, e) => Application.Exit();
            exit.Image = Properties.Resources.ico_delete;
        }

        private static void PingAll()
        {
            DateTime last = DateTime.Now;
            while (true)
            {
                Task.WaitAll(TargetManager.Targets.Where(x => x.AutoPing).Select(x => x.Ping()).ToArray());
                var now = DateTime.Now;
                var diff = now - last;
                if ((int)diff.TotalMilliseconds < Config.PingIntervals)
                {
                    Thread.Sleep(Config.PingIntervals - (int)diff.TotalMilliseconds);
                }
                last = DateTime.Now;
            }
        }
    }
}
