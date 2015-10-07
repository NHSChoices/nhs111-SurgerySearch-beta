using System;
using System.Net;
using System.Threading.Tasks;

namespace SurgerySearch.Utils.Helpers
{
    internal class RestfulHelper
    {
        public RestfulHelper()
        {
            WebClient = new WebClient();
        }

        private WebClient WebClient { get; set; }

        public async Task<string> GetAsync(string url)
        {
            return await WebClient.DownloadStringTaskAsync(new Uri(url));
        }
    }
}