using IPLogger.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Data
{
    public static class Config
    {
        public static bool AutoStartSystem
        {
            get => autoStartSystem;
            set
            {
                if (value != autoStartSystem)
                {
                    autoStartSystem = value;
                    file.WriteBool("AutoStartSystem", value);
                    var assembly = Assembly.GetExecutingAssembly();
                    if (value) AutoStartHelper.Enable(assembly.GetName().Name, new FileInfo(assembly.Location));
                    else AutoStartHelper.Disable(assembly.GetName().Name);
                }
            }
        }
        public static bool AutoStartPinging
        {
            get => autoStartPinging;
            set
            {
                autoStartPinging = value;
                file.WriteBool("AutoStartPinging", value);
            }
        }
        public static int PingIntervals
        {
            get => pingIntervals;
            set
            {
                pingIntervals = value;
                file.WriteInt("PingIntervals", value);
            }
        }
        public static int PingTimeout
        {
            get => pingTimeouts;
            set
            {
                pingTimeouts = value;
                file.WriteInt("PingTimeout", value);
            }
        }

        private static bool autoStartSystem, autoStartPinging;
        private static int pingIntervals, pingTimeouts;
        private static IniFile file;

        public static void Initialize()
        {
            if (file != null) return;
            file = new IniFile(FileHelper.Configs.FullName);
            AutoStartSystem = file.ReadBool("AutoStartSystem", false);
            AutoStartPinging = file.ReadBool("AutoStartPinging", false);
            PingIntervals = file.ReadInt("PingIntervals", 1000);
            PingTimeout = file.ReadInt("PingTimeout", 1000);
        }
    }
}
