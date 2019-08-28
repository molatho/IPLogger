using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Data
{
    public interface IDataPointProvider
    {
        IEnumerable<DataPoint> GetAll();
        IEnumerable<DataPoint> GetLatest(TimeSpan maxAge);
        IEnumerable<DataPoint> GetBetween(DateTime from, DateTime to);
    }
}
