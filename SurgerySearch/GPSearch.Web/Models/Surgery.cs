using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurgerySearch.Web.Models
{
    [ElasticType(IdProperty="surgeryId")]
    public class Surgery
    {
        public string surgeryId { get; set; }
        public string name { get; set; }
        //public string nationalGrouping { get; set; }
        //public string healthGeography { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string address4 { get; set; }
        public string address5 { get; set; }
        public string postcode { get; set; }
        public string openDate { get; set; }
        public string closeDate { get; set; }
        public string statusCode { get; set; }
        public string subtypeCode { get; set; }
        //public string comissioner { get; set; }
        //public string joinProviderDate { get; set; }
        //public string leftProviderDate { get; set; }
        public string contactPhone { get; set; }
        //public string amendRecordIndicator { get; set; }
        //public string providerOrPurchase { get; set; }
        public string prescribingSettings { get; set; }
    }
}