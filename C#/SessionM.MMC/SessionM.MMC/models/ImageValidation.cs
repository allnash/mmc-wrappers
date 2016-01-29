using Newtonsoft.Json;
using SessionM.MMC.models.intefaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace SessionM.MMC.models
{

    public class ImageValidation : ISMModel
    {
        [DefaultValue(null)]
        [JsonProperty("validation_type")]
        public string validationType { get; set; }

        [DefaultValue(null)]
        [JsonProperty("campaign_id")]
        public int campaignId { get; set; }

        [DefaultValue(null)]
        [JsonProperty("placement_id")]
        public int placementId { get; set; }

        [DefaultValue(null)]
        [JsonProperty("images")]
        public IList<ImageValidationItem> images { get; set; }

        [DefaultValue(null)]
        [JsonProperty("status")]
        public string status { get; set; }

        [DefaultValue(null)]
        [JsonProperty("created_at")]
        public string createdAt { get; set; }

        [DefaultValue(null)]
        [JsonProperty("image_count")]
        public int imageCount { get; set; }

        [DefaultValue(null)]
        [JsonProperty("data")]
        public object data { get; set; }

        [DefaultValue(null)]
        public object error { get; set; }
    }

}
