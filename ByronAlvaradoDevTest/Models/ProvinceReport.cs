using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByronAlvaradoDevTest.Models
{
    public class ProvinceReport
    {
        [JsonProperty("data")]
        public List<Province> Provinces { get; set; }
    }
}