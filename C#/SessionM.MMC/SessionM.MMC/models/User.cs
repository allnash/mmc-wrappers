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

    public class User : ISMModel
    {
        [DefaultValue(null)]
        [JsonProperty("id")]
        public string id { get; set; }

        [DefaultValue(null)]
        [JsonProperty("external_id")]
        public string external_id { get; set; }

        [DefaultValue(null)]
        [JsonProperty("email")]
        public string email { get; set; }

        [DefaultValue(null)]
        [JsonProperty("gender")]
        public string gender { get; set; }

        [DefaultValue(null)]
        [JsonProperty("dob")]
        public string dob { get; set; }

        [DefaultValue(null)]
        [JsonProperty("ip")]
        public string ip { get; set; }

        [DefaultValue(0)]
        [JsonProperty("available_points")]
        public int available_points { get; set; }

        [DefaultValue(0)]
        [JsonProperty("test_points")]
        public int test_points { get; set; }

        [DefaultValue(0)]
        [JsonProperty("unclaimed_achievement_count")]
        public int unclaimed_achievement_count { get; set; }

        [DefaultValue(null)]
        [JsonProperty("created_at")]
        public DateTime? created_at { get; set; }

        [DefaultValue(null)]
        [JsonProperty("updated_at")]
        public DateTime? updated_at { get; set; }

        [DefaultValue(false)]
        [JsonProperty("suspended")]
        public bool suspended { get; set; }

        [DefaultValue(null)]
        [JsonProperty("tier")]
        public string tier { get; set; }

        [DefaultValue(0.0)]
        [JsonProperty("next_tier_percentage")]
        public double next_tier_percentage { get; set; }

        [DefaultValue(null)]
        [JsonProperty("account_status")]
        public string account_status { get; set; }

        [DefaultValue(null)]
        [JsonProperty("user_profile")]
        public Dictionary<string, string> user_profile;

        [DefaultValue(null)]
        [JsonProperty("meta")]
        public Dictionary<string, string> meta;

        [DefaultValue(null)]
        [JsonProperty("phone")]
        public string phoneNumber { get; set; }

        [DefaultValue(null)]
        [JsonProperty("message")]
        public string message { get; set; }

        [DefaultValue(null)]
        [JsonProperty("auth_token")]
        public string auth_token { get; set; }

        [DefaultValue(null)]
        [JsonProperty("expires")]
        public string expires { get; set; }

        [DefaultValue(null)]
        [JsonProperty("proxy_id")]
        public ProxyId proxyId { get; set; }

        [DefaultValue(null)]
        [JsonProperty("proxy_ids")]
        public IList<string> proxyIds { get; set; }

        [DefaultValue(null)]
        [JsonProperty("transactions")]
        public IList<UserTransactionItem> transactions { get; set; }

        public object error { get; set; }

        public string cursor { get; set; }
    }

}
