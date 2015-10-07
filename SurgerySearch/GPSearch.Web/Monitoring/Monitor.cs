using System;
using System.Threading.Tasks;
using Nest;
using SurgerySearch.Utils.Configuration;
using SurgerySearch.Utils.Elasticsearch;
using SurgerySearch.Utils.Monitoring;

namespace SurgerySearch.Web.Monitoring
{
    public class Monitor : BaseMonitor
    {
        private readonly IElasticsearchClientFeature _elasticsearchClientFeature;

        public Monitor()
        {
            _elasticsearchClientFeature = new ElasticsearchClientFeature();
        }

        public override string Metrics()
        {
            return "Metrics";
        }

        public override bool Health()
        {
            try
            {
                return _elasticsearchClientFeature.CheckClusterHealthStatus();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}