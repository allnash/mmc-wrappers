using Newtonsoft.Json;
using SessionM.MMC.models.intefaces;
using System.ComponentModel;

namespace SessionM.MMC.models
{

    public class Verification : ISMModel
    {
        [DefaultValue(null)]
        [JsonProperty("id")]
        public int id { get; set; }

        [DefaultValue(null)]
        [JsonProperty("status")]
        public string status { get; set; }

        [DefaultValue(null)]
        [JsonProperty("mode")]
        public string mode { get; set; }

        [DefaultValue(null)]
        [JsonProperty("code")]
        public string code { get; set; }

        /// <summary>
        /// Errors related to verification code validation
        /// </summary>
        [DefaultValue(null)]
        public object error { get; set; }
    }

}
