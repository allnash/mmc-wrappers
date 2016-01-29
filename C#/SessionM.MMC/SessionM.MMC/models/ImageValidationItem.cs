using Newtonsoft.Json;
using System.ComponentModel;

namespace SessionM.MMC.models
{
    public class ImageValidationItem
    {
        public ImageValidationItem(string base64data, string mediaType)
        {
            this.Base64Data = base64data;
            this.mimeType = mediaType;
        }

        [JsonProperty("base64_data")]
        public string Base64Data { get; set; }

        [JsonProperty("mime_type")]
        public string mimeType { get; set; }

        [DefaultValue(null)]
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}