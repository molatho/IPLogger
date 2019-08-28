using IPLogger.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Data
{
    public class Target : IDisposable, IDataPointProvider
    {
        public IEnumerable<DataPoint> DataPoints => dataPoints;
        public IPAddress Address => sync.Address;
        public string Name => sync.Name;
        public FileInfo File => sync.File;
        public float Uptime24h => GetUptime(GetLastDay());
        public float UptimeAll => GetUptime(GetAll());
        public int Downtimes24h => GetDownTimes(GetLastDay()).Length;
        public int DowntimesAll => GetDownTimes(GetAll()).Length;
        public DataPoint LatestDataPoint { get; private set; }
        public bool AutoPing
        {
            get { return autoPing; }
            set
            {
                if (autoPing != value)
                {
                    autoPing = value;
                    AutoPingChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        public event EventHandler DataPointAdded;
        public event EventHandler AutoPingChanged;

        private List<DataPoint> dataPoints;
        private FileSync sync;
        private bool autoPing;
        private object _lock = new object();

        public Target(FileInfo info)
        {
            sync = new FileSync(info);
            dataPoints = new List<DataPoint>(sync.ReadPoints());
            AutoPing = Config.AutoStartPinging;
        }
        public Target(string name, IPAddress address)
        {
            var file = FileHelper.CreateTargetFile(Guid.NewGuid().ToString());

            sync = new FileSync(file, name, address);
            dataPoints = new List<DataPoint>();
        }

        //public static DirectoryInfo GetLogDirectory()
        //{
        //    var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
        //    var folder = assembly.Directory;
        //    var logs = Path.Combine(folder.FullName, "Logs");
        //    return new DirectoryInfo(logs);
        //}
        //public static Target[] GetLogTargets()
        //{
        //    var directory = GetLogDirectory();
        //    if (!directory.Exists) return new Target[0];
        //    var targets = new List<Target>();
        //    foreach (var file in directory.GetFiles("*.ipt"))
        //    {
        //        targets.Add(new Target(file));
        //    }
        //    return targets.ToArray();
        //}
        //public static FileInfo GetLogFilePath(IPAddress address)
        //{
        //    var fileName = string.Format("{0}.ipt",
        //        string.Join("-", address.GetAddressBytes().Select(x => x.ToString()).ToArray()));
        //    return new FileInfo(Path.Combine(GetLogDirectory().FullName, fileName));
        //}

        public void AddDataPoint(short latency, IPStatus status)
        {
            var dp = new DataPoint(latency, status, DateTime.Now);
            lock (_lock)
            {
                dataPoints.Add(dp);
            }
            sync.Add(dp);
            LatestDataPoint = dp;
            DataPointAdded?.Invoke(this, new EventArgs());
        }

        public async Task<short> Ping()
        {
            try
            {
                var reply = await new Ping().SendPingAsync(Address, Config.PingTimeout);
                AddDataPoint((short)reply.RoundtripTime, reply.Status);
                if (reply.Status != IPStatus.Success)
                    return -1;
                return (short)reply.RoundtripTime;
            }
            catch { return -1; }
        }

        public void Dispose()
        {
            sync.Dispose();
        }
        public IEnumerable<DataPoint> GetLastDay()
        {
            return GetLatest(TimeSpan.FromDays(1));
        }
        public IEnumerable<DataPoint> GetAll()
        {
            lock (_lock)
            {
                return this.dataPoints.ToArray();
            }
        }

        public Downtime[] GetDownTimes(IEnumerable<DataPoint> data)
        {
            bool isSuccess = true;
            int cnt = 0;
            List<Downtime> downtimes = new List<Downtime>();
            List<DataPoint> dps = new List<DataPoint>();
            foreach (var entry in data)
            {
                if (!entry.Success)
                    dps.Add(entry);

                if (isSuccess != entry.Success) //Change
                {
                    if (entry.Success && dps.Count > 0) //Went OK
                    {
                        downtimes.Add(new Downtime(dps));
                        dps.Clear();
                    }
                    else //Went bad
                    {
                    }
                    isSuccess = entry.Success;
                }
            }
            if (!isSuccess && dps.Count > 0)
                downtimes.Add(new Downtime(dps));
            return downtimes.ToArray();
        }
        public float GetUptime(IEnumerable<DataPoint> data)
        {
            var total = 0;
            var success = 0;
            foreach (var d in data)
            {
                total++;
                if (d.Success) success++;
            }
            if (total == 0) return 0f;
            return (float)success / (float)total;
        }
        public IEnumerable<DataPoint> GetLatest(TimeSpan maxAge)
        {
            lock (_lock)
            {
                return this.dataPoints.Where(x => (DateTime.Now - x.TimeStamp) <= maxAge).ToArray();
            }
        }

        public IEnumerable<DataPoint> GetBetween(DateTime from, DateTime to)
        {
            lock (_lock)
            {
                return this.dataPoints.Where(x => x.TimeStamp >= from && x.TimeStamp <= to).ToArray();
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Address})";
        }
    }
}
