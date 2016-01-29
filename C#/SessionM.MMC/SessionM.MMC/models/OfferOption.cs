using Newtonsoft.Json;
using SessionM.MMC.models.intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.models
{
    public class OfferOption : ISMModel
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [DefaultValue(null)]
        [JsonProperty("name")]
        public string name { get; set; }
        [DefaultValue(null)]
        [JsonProperty("type")]
        public string type { get; set; }
        [DefaultValue(null)]
        [JsonProperty("description")]
        public string description { get; set; }
        [DefaultValue(0)]
        [JsonProperty("points")]
        public int points { get; set; }
        [DefaultValue(null)]
        [JsonProperty("tier")]
        public object tier { get; set; }
        [DefaultValue(null)]
        [JsonProperty("status")]
        public string status { get; set; }
        [DefaultValue(null)]
        [JsonProperty("logo")]
        public string logo { get; set; }
        [DefaultValue(null)]
        [JsonProperty("data")]
        public object data { get; set; }


    }
}
