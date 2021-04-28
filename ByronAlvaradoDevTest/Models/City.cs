using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByronAlvaradoDevTest.Models
{
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("fips")]
        public int Fips { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("confirmed_diff")]
        public int ConfirmedDiff { get; set; }

        [JsonProperty("deaths_diff")]
        public int DeathsDiff { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }
    }

}