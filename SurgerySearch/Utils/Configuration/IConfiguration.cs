using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurgerySearch.Utils.Configuration
{
    public interface IConfiguration
    {
        string ElasticsearchBaseUrl { get; }
        string SurgeriesIndex { get; }
        int DefaultPageSize { get;  }
    }

}
