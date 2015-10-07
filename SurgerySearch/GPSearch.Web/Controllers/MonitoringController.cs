using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SurgerySearch.Web.Models;
using SurgerySearch.Web.Services;
using SurgerySearch.Web.Filters;
using SurgerySearch.Utils.Monitoring;

namespace SurgerySearch.Web.Controllers
{
    public class MonitoringController : ApiController
    {
        private IMonitor _monitor;
        public MonitoringController()
        {
            _monitor = new SurgerySearch.Web.Monitoring.Monitor();
        }

        [HttpGet]
        [Route("Monitor/{service}")]
        public string MonitorPing(string service)
        {
            switch (service.ToLower())
            {
                case "ping":
                    return _monitor.Ping();

                case "metrics":
                    return _monitor.Metrics();

                case "health":
                    return _monitor.Health().ToString();

            }

            return null;
        }
    }
}
