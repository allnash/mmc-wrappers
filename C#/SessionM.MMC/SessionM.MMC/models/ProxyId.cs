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
    public class ProxyId
    {
        [DefaultValue(null)]
        [JsonProperty("register")]
        public string register { get; set; }

        [DefaultValue(null)]
        [JsonProperty("unregister")]
        public string unregister { get; set; }

    }
}