using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Utils
{
    public static class FileHelper
    {
        public static DirectoryInfo Root { get; private set; } = GetRoot();
        public static DirectoryInfo Logs { get; private set; } = GetCreateSubDirectory(Root, "Logs");
        public static FileInfo Configs { get; private set; } = GetCreateFile(Root, "IPLogger.ini");
        public static IEnumerable<FileInfo> TargetFiles => Logs.GetFiles("*.ipt");

        public static FileInfo CreateTargetFile(string name)
        {
            return GetCreateFile(Logs, $"{name}.ipt");
        }

        private static FileInfo GetCreateFile(DirectoryInfo root, string name)
        {
            var file = new FileInfo(Path.Combine(root.FullName, name));
            if (!file.Exists) file.Create().Dispose();
            return file;
        }

        private static DirectoryInfo GetCreateSubDirectory(DirectoryInfo root, string name)
        {
            var dir = new DirectoryInfo(Path.Combine(root.FullName, name));
            if (!dir.Exists) dir.Create();
            return dir;
        }
        private static DirectoryInfo GetRoot()
        {
            var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
            return assembly.Directory;
        }
    }
}
