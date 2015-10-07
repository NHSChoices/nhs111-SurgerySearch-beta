using System.Threading.Tasks;

namespace SurgerySearch.Utils.Monitoring
{
    public abstract class BaseMonitor : IMonitor
    {
        public string Ping()
        {
            return "pong";
        }

        public abstract string Metrics();

        public abstract bool Health();
    }
}