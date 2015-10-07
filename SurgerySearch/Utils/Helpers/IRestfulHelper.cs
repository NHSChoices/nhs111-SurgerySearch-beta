using System.Threading.Tasks;

namespace SurgerySearch.Utils.Helpers
{
    internal interface IRestfulHelper
    {
        Task<string> GetAsync(string url);
    }
}