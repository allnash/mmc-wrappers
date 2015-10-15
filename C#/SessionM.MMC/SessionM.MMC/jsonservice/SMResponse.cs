using Newtonsoft.Json;
using SessionM.MMC.models;
using SessionM.MMC.models.attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.JsonService
{
    public class Errors
    {
        [DefaultValue(null)]
        [JsonProperty("message")]
        public string message { get; set; }
    }

    public class Model
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("request_key")]
        public string request_key { get; set; }
        [JsonProperty("attributes")]
        public MyAttributesModel attributes { get; set; }
    }

    public class SMResponse
    {
        [DefaultValue(null)]
        [JsonProperty("status")]
        public string status { get; set; }
        [DefaultValue(null)]
        [JsonProperty("errors")]
        public Errors errors { get; set; }
        [DefaultValue(null)]
        [JsonProperty("user")]
        public User user { get; set; }
        [DefaultValue(null)]
        [JsonProperty("model")]
        public Model model { get; set; }
        [DefaultValue(null)]
        [JsonProperty("offers")]
        public IList<Offer> offers { get; set; }
        [DefaultValue(null)]
        [JsonProperty("order")]
        public Order order { get; set; }

    }
}
