using Newtonsoft.Json;
using SessionM.MMC.models;
using SessionM.MMC.models.attributes;
using SessionM.MMC.models.intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.JsonService
{
    public class SMRequest
    {
        [DefaultValue(null)]
        [JsonProperty("user")]
        public User user { get; set; }
        [DefaultValue(null)]
        [JsonProperty("attributes")]
        public IAttributes attributes { get; set; }
        [DefaultValue(null)]
        [JsonProperty("order")]
        public Order order { get; set; }
        [DefaultValue(null)]
        [JsonProperty("events")]
        public IEvents events { get; set; }
        [DefaultValue(false)]
        [JsonProperty("auto_claim")]
        public bool autoClaim { get; set; }

        [DefaultValue(null)]
        [JsonProperty("image_validation")]
        public ImageValidation imageValidation { get; set; }

        [DefaultValue(null)]
        [JsonProperty("challenge")]
        public Challenge challenge { get; set; }

        [DefaultValue(null)]
        [JsonProperty("verification")]
        public Verification verification { get; set; }

    }
}
