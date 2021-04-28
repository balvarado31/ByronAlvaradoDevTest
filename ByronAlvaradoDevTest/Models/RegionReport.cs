using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByronAlvaradoDevTest.Models
{
    public class RegionReport
    {
        [JsonProperty("data")]
        public List<Region> Regions { get; set; }
    }
}