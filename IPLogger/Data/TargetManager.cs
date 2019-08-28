using IPLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Data
{
    public static class TargetManager
    {
        public static event EventHandler<TargetEventArgs> TargetAdded;
        public static event EventHandler<TargetEventArgs> TargetRemoved;
        public static event EventHandler<TargetEventArgs> TargetUpdated;
        public static IEnumerable<Target> Targets
        {
            get
            {
                if (targets == null) return Initialize();
                return targets;
            }
        }
        private static List<Target> targets;

        public static IEnumerable<Target> Initialize()
        {
            if (targets != null) return targets;
            targets = new List<Target>(FileHelper.TargetFiles.Select(x => new Target(x)));
            return targets;
        }

        //public static Target[] AddTargets(string hostname)
        //{
        //    var addresses = Dns.GetHostAddresses(hostname);
        //    var _targets = addresses.Select(x => new Target(hostname, x)).ToArray();
        //    targets.AddRange(_targets);

        //    foreach (var t in _targets)
        //        TargetAdded?.Invoke(null, new TargetEventArgs(t));

        //    return _targets;
        //}
        public static Target CreateTarget(string name, IPAddress address)
        {
            var target = new Target(name, address);
            targets.Add(target);

            TargetAdded?.Invoke(null, new TargetEventArgs(target));

            return target;
        }
        public static Target RemoveTarget(Target target)
        {
            targets.Remove(target);
            target.AutoPing = false;
            target.Dispose();
            target.File.Delete();

            TargetRemoved?.Invoke(null, new TargetEventArgs(target));

            return target;
        }

        public static void DisposeAll()
        {
            foreach (var t in targets)
                t.Dispose();
        }

        public class TargetEventArgs : EventArgs
        {
            public Target Target { get; private set; }
            public TargetEventArgs(Target target)
            {
                Target = target;
            }
        }
    }
}
