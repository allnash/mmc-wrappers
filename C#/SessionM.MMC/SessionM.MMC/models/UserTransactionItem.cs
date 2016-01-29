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
    public class UserTransactionItem
    {
        [DefaultValue(null)]
        [JsonProperty("balance")]
        public int balance { get; set; }

        [DefaultValue(null)]
        [JsonProperty("date")]
        public string date { get; set; }

        [DefaultValue(null)]
        [JsonProperty("description")]
        public string description { get; set; }

        [DefaultValue(null)]
        [JsonProperty("points")]
        public int points { get; set; }

        [DefaultValue(null)]
        [JsonProperty("record_id")]
        public string recordId { get; set; }

        [DefaultValue(null)]
        [JsonProperty("transaction")]
        public string transaction { get; set; }

        [DefaultValue(null)]
        [JsonProperty("type")]
        public string transactionType { get; set; }
    }
}