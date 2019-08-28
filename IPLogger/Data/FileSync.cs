using IPLogger.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace IPLogger.Data
{
    public class FileSync : IDisposable
    {
        public string Name { get; private set; }
        public IPAddress Address { get; private set; }
        public FileInfo File { get; private set; }

        private object _lock = new object();
        private Stream file, fileIO;
        private long headerLength;

        private void WriteSync(byte[] data, long pos = -1)
        {
            lock (_lock)
            {
                var _pos = fileIO.Position;
                if (pos >= 0) fileIO.Position = pos;
                fileIO.Write(data, 0, data.Length);
            }
        }

        public FileSync(FileInfo fileInfo)
        {
            File = fileInfo;
            file = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileIO = new TimeBufferedStream(file, TimeSpan.FromSeconds(10));
            ReadHeader();
        }

        public FileSync(FileInfo fileInfo, string name, IPAddress address)
        {
            File = fileInfo;
            file = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileIO = new TimeBufferedStream(file, TimeSpan.FromSeconds(10));
            WriteHeader(name, address);
        }

        private void WriteHeader(string name, IPAddress address)
        {
            Address = address;
            Name = name;
            var bytes = Encoding.UTF8.GetBytes(Name);
            WriteSync(new byte[] { (byte)bytes.Length }, 0);
            WriteSync(bytes);
            bytes = address.GetAddressBytes();
            WriteSync(new byte[] { (byte)bytes.Length });
            WriteSync(bytes);
        }

        private void ReadHeader()
        {
            fileIO.Position = 0;

            var nameLengthBytes = new byte[1];
            fileIO.Read(nameLengthBytes, 0, nameLengthBytes.Length);
            var nameBytes = new byte[nameLengthBytes[0]];
            fileIO.Read(nameBytes, 0, nameBytes.Length);
            Name = Encoding.UTF8.GetString(nameBytes);

            var addressLengthBytes = new byte[1];
            fileIO.Read(addressLengthBytes, 0, addressLengthBytes.Length);
            var addressBytes = new byte[addressLengthBytes[0]];
            fileIO.Read(addressBytes, 0, addressBytes.Length);
            Address = new IPAddress(addressBytes);

            headerLength = fileIO.Position;
        }

        public IEnumerable<DataPoint> ReadPoints()
        {
            fileIO.Position = headerLength;
            DataPoint dp;
            while (true)
            {
                try
                {
                    dp = DataPoint.FromStream(fileIO);
                }
                catch { break; }
                yield return dp;
            }
            fileIO.Position = fileIO.Length;
        }

        public void Add(DataPoint dp)
        {
            DataPoint.ToStream(dp, fileIO);
        }

        public void Dispose()
        {
            if (fileIO != null)
            {
                fileIO.Flush();
                fileIO.Dispose();
            }
            if (file != null) file.Dispose();
        }
    }
}
