using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace IPLogger.Data
{
    public class DataPoint
    {
        public DateTime TimeStamp { get; private set; }
        public short Latency { get; private set; }
        public IPStatus Status { get; private set; }
        public bool Success => Status == IPStatus.Success;

        public DataPoint(short latency, IPStatus status, DateTime timeStamp)
        {
            Latency = latency;
            Status = status;
            TimeStamp = timeStamp;
        }

        public override string ToString()
        {
            if (Success)
                return $"{TimeStamp.ToShortDateString()} - {TimeStamp.ToLongTimeString()}: {Latency}ms";
            return $"{TimeStamp.ToShortDateString()} - {TimeStamp.ToLongTimeString()}: {Status}";
        }

        public static DataPoint FromStream(Stream str)
        {
            byte[] buffer = new byte[12];
            int count = str.Read(buffer, 0, buffer.Length);
            if (count < buffer.Length) throw new EndOfStreamException();
            var latency = BitConverter.ToInt16(!BitConverter.IsLittleEndian ? buffer.Take(2).Reverse().ToArray() : buffer.Take(2).ToArray(), 0);
            var status = BitConverter.ToInt16(!BitConverter.IsLittleEndian ? buffer.Skip(2).Take(2).Reverse().ToArray() : buffer.Skip(2).Take(2).ToArray(), 0);
            var ticks = BitConverter.ToInt64(!BitConverter.IsLittleEndian ? buffer.Skip(4).Take(8).Reverse().ToArray() : buffer.Skip(4).Take(8).ToArray(), 0);
            return new DataPoint(latency, (IPStatus)status, new DateTime(ticks));
        }
        public static void ToStream(DataPoint dp, Stream str)
        {
            var buffer = !BitConverter.IsLittleEndian ?
                BitConverter.GetBytes(dp.Latency).Reverse()
                    .Concat(BitConverter.GetBytes((short)dp.Status).Reverse())
                    .Concat(BitConverter.GetBytes(dp.TimeStamp.Ticks).Reverse())
                    .ToArray() :
                BitConverter.GetBytes(dp.Latency)
                    .Concat(BitConverter.GetBytes((short)dp.Status))
                    .Concat(BitConverter.GetBytes(dp.TimeStamp.Ticks))
                    .ToArray();
            str.Write(buffer, 0, buffer.Length);
        }

        public override bool Equals(object obj)
        {
            return obj is DataPoint point &&
                   TimeStamp == point.TimeStamp &&
                   Latency == point.Latency &&
                   Status == point.Status;
        }

        public override int GetHashCode()
        {
            var hashCode = 272928259;
            hashCode = hashCode * -1521134295 + TimeStamp.GetHashCode();
            hashCode = hashCode * -1521134295 + Latency.GetHashCode();
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            return hashCode;
        }
    }
}
