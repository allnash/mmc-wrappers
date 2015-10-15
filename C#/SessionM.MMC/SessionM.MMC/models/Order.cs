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
    public class Order : ISMModel
    {
        [DefaultValue(0)]
        [JsonProperty("id")]
        public int id { get; set; }
        [DefaultValue(0)]
        [JsonProperty("quantity")]
        public int quantity { get; set; }
        [DefaultValue(null)]
        [JsonProperty("recaptcha_challenge_field")]
        public string recaptcha_challenge_field { get; set; }
        [DefaultValue(null)]
        [JsonProperty("recaptcha_response_field")]
        public string recaptcha_response_field { get; set; }
        [DefaultValue(null)]
        [JsonProperty("ip")]
        public string ip { get; set; }
        [DefaultValue(null)]
        [JsonProperty("email")]
        public string email { get; set; }
        [DefaultValue(0)]
        [JsonProperty("offer_id")]
        public int offer_id { get; set; }
        [DefaultValue(null)]
        [JsonProperty("user_id")]
        public string user_id { get; set; }
        [DefaultValue(0)]
        [JsonProperty("points")]
        public int points { get; set; }
        [DefaultValue(null)]
        [JsonProperty("status")]
        public string status { get; set; }
        [DefaultValue(null)]
        [JsonProperty("created_at")]
        public DateTime? created_at { get; set; }
        [DefaultValue(null)]
        [JsonProperty("name")]
        public string name { get; set; }
        [DefaultValue(null)]
        [JsonProperty("logo")]
        public string logo { get; set; }
        [DefaultValue(null)]
        [JsonProperty("description")]
        public string description { get; set; }
    }


}
