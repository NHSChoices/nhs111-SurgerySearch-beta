using System;
using System.Threading.Tasks;
using Nest;
using SurgerySearch.Utils.Configuration;

namespace SurgerySearch.Utils.Elasticsearch
{
    public class ElasticsearchClientFeature : IElasticsearchClientFeature
    {
        private IConfiguration _configuration;
        public IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                    return _configuration = new Configuration.Configuration();
                return _configuration;

            }
        }

        private ElasticClient _elasticClient;
        public ElasticClient ElasticClient
        {
            get
            {
                if (_elasticClient == null)
                    InitializeElasticsearch();
                return _elasticClient;
            }
        }

        private void InitializeElasticsearch()
        {
            var node = new Uri(Configuration.ElasticsearchBaseUrl);
            var esConfig = new ConnectionSettings(node, defaultIndex: Configuration.SurgeriesIndex);
            _elasticClient = new ElasticClient(esConfig);
        }

        public bool CheckClusterHealthStatus()
        {
            var status =  ElasticClient.ClusterHealth();
            return status.Status == "green" || status.Status == "yellow";
        }
    }

    public interface IElasticsearchClientFeature
    {
        IConfiguration Configuration { get; }
        ElasticClient ElasticClient { get; }
        bool CheckClusterHealthStatus();
    }
}