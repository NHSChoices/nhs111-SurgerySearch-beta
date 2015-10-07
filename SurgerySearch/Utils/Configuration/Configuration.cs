using System.Configuration;

namespace SurgerySearch.Utils.Configuration
{
    public class Configuration : IConfiguration
    {

        public string ElasticsearchBaseUrl
        {
            get { return ConfigurationManager.AppSettings["ElasticsearchBaseUrl"]; }
        }


        public string SurgeriesIndex
        {
            get { return ConfigurationManager.AppSettings["SurgeriesIndex"]; }
        }


        public int DefaultPageSize
        {
            get { return int.Parse(ConfigurationManager.AppSettings["DefaultPageSize"]); }
        }
    }
}
