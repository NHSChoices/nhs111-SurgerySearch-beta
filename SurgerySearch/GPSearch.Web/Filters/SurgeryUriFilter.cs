using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurgerySearch.Web.Filters
{
    public class SurgeryUriFilter
    {
        public int page { get; set; }
        public int count { get; set; }
        public string Postcode { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}