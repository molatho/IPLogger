using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Utils
{
    /// <summary>
    /// Mostly copied from: https://stackoverflow.com/a/14906422
    /// </summary>
    public class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public bool ReadBool(string Key, bool defaultValue = false)
        {
            var val = Read(Key);
            if (bool.TryParse(val, out bool res))
                return res;
            return defaultValue;
        }
        public int ReadInt(string Key,  int defaultValue = 0)
        {
            var val = Read(Key);
            if (int.TryParse(val, out int res))
                return res;
            return defaultValue;
        }

        public void Write(string Key, string Value)
        {
            WritePrivateProfileString(EXE, Key, Value, Path);
        }
        public void WriteBool(string Key, bool Value)
        {
            Write(Key, Value.ToString());
        }
        public void WriteInt(string Key, int Value)
        {
            Write(Key, Value.ToString());
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null);
        }
        public void DeleteSection(string Section = null)
        {
            Write(null, null);
        }
        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key).Length > 0;
        }
    }
}
