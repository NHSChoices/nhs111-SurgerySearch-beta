using System.Threading.Tasks;

namespace SurgerySearch.Utils.Monitoring
{
    public interface IMonitor
    {
        string Ping();
        string Metrics();
        bool Health();
    }
}