using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Data
{
    public class Downtime
    {
        public DataPoint[] Measures { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public TimeSpan Duration => To - From;

        public Downtime(IEnumerable<DataPoint> measures)
        {
            Measures = measures.OrderBy(x => x.TimeStamp).ToArray();
            From = Measures.First().TimeStamp;
            To = Measures.Last().TimeStamp;
        }

        public override string ToString()
        {
            if (Duration > TimeSpan.Zero)
                return string.Format("[{0} {1} - {2} {3}] Down: {4}",
                    From.ToShortDateString(),
                    From.ToLongTimeString(),
                    To.ToShortDateString(),
                    To.ToLongTimeString(),
                    Duration.TotalDays >= 1
                    ? Duration.ToString(@"dd hh\:mm\:ss")
                    : Duration.ToString(@"hh\:mm\:ss"));
            return string.Format("[{0} {1}] Down",
                From.ToShortDateString(),
                From.ToLongTimeString());
        }

        public override bool Equals(object obj)
        {
            return obj is Downtime downtime &&
                   EqualityComparer<DataPoint[]>.Default.Equals(Measures, downtime.Measures) &&
                   From == downtime.From &&
                   To == downtime.To;
        }

        public override int GetHashCode()
        {
            var hashCode = 1468869445;
            hashCode = hashCode * -1521134295 + EqualityComparer<DataPoint[]>.Default.GetHashCode(Measures);
            hashCode = hashCode * -1521134295 + From.GetHashCode();
            hashCode = hashCode * -1521134295 + To.GetHashCode();
            return hashCode;
        }
    }
}
