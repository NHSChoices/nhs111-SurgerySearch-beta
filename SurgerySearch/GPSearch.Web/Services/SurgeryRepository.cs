using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using SurgerySearch.Utils.Elasticsearch;
using SurgerySearch.Web.Models;
using Nest;
using SurgerySearch.Utils.Configuration;

namespace SurgerySearch.Web.Services
{
    public class SurgeryRepository
    {
        private readonly IElasticsearchClientFeature _elasticsearchClientFeature;

        public SurgeryRepository()
        {
            _elasticsearchClientFeature = new ElasticsearchClientFeature();
        }

        public async Task<List<Surgery>> GetAllSurgeriesFrom(int pageNumber, int pageSize)
        {
            if (pageSize == 0)
            {
                pageSize = _elasticsearchClientFeature.Configuration.DefaultPageSize;
            }

            var searchResults = await _elasticsearchClientFeature.ElasticClient.SearchAsync<Surgery>(s => s
                .From(pageNumber)
                .Size(pageSize)
                .Query(q=>q.MatchAll())
                );

            return searchResults.Documents.ToList();
        }

        public async Task<List<Surgery>> SearchSurgeryByName(int pageNumber, int pageSize, string name)
        {
            if (pageSize == 0)
            {
                pageSize = _elasticsearchClientFeature.Configuration.DefaultPageSize;
            }

            const string gpPracticePrescribingLevel = "4";
            const string closedStatusCode = "C";

            var searchResults = await _elasticsearchClientFeature.ElasticClient.SearchAsync<Surgery>(s => s
                .From(pageNumber)
                .Size(pageSize)
                .Query(q =>
                    q.Terms(p=>p.name, name.Split(' '))
                    && q.Term(p => p.prescribingSettings, gpPracticePrescribingLevel)
                    && q.Bool(bq => bq.MustNot(mq => mq.Term(p=>p.statusCode, closedStatusCode)))
                ));

            return searchResults.Documents.ToList();
        }

        public async Task<Surgery> GetSurgery(string surgeryId)
        {

            var searchResults = await _elasticsearchClientFeature.ElasticClient.SearchAsync<Surgery>(s => s
                .Query(q => q.Term("_id", surgeryId))
                );

            return searchResults.Documents.FirstOrDefault<Surgery>();
        }
    }
}