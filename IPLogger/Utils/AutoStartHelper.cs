using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Utils
{
    public static class AutoStartHelper
    {
        private const string PATH = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static RegistryKey RUN = FindRunKey(Registry.CurrentUser, PATH.Split('\\'));

        private static RegistryKey FindRunKey(RegistryKey root, string[] pathParts)
        {
            var key = root.OpenSubKey(pathParts[0], pathParts.Length == 1);
            if (pathParts.Length > 1)
                return FindRunKey(key, pathParts.Skip(1).ToArray());
            else
                return key;
        }

        private static string GetAutoStartEntry(string name)
        {
            var value = RUN.GetValue(PATH, name) as string;
            return value;
        }

        private static void SetAutoStartEntry(string name, string value)
        {
            RUN.SetValue(name, value, RegistryValueKind.String);
        }

        public static bool IsEnabled(string appName)
        {
            return !string.IsNullOrEmpty(GetAutoStartEntry(appName));
        }
        public static void Enable(string appName, FileInfo path, params string[] parameters)
        {
            string value = parameters.Length > 0
                ? string.Format("\"{0}\" {1}", path.ToString(), string.Join(" ", parameters))
                : string.Format("\"{0}\"", path.ToString());
            SetAutoStartEntry(appName, value);
        }
        public static void Disable(string appName)
        {
            RUN.DeleteValue(appName);
        }
    }
}
