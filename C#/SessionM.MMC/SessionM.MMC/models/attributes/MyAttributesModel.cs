using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SessionM.MMC.models.attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.models
{
    public class MyAttributesModel : IAttributes
    {
        public class UserTitle
        {
            [DefaultValue(null)]
            [JsonProperty("type")]
            public AttributesMetaModel.DataType type { get; set; }
            [DefaultValue(null)]
            [JsonProperty("filters")]
            public IList<AttributesMetaModel.Filters> filters { get; set; }
            [DefaultValue(null)]
            [JsonProperty("caseinsensitive")]
            public bool caseinsensitive { get; set; }
            [DefaultValue(null)]
            [JsonProperty("inclusion")]
            public IList<string> inclusion { get; set; }
            [DefaultValue(null)]
            [JsonProperty("exclusion")]
            public IList<string> exclusion { get; set; }
            [DefaultValue(null)]
            [JsonProperty("format")]
            public string format { get; set; }
            [DefaultValue(null)]
            [JsonProperty("length")]
            public AttributesMetaModel.Length length { get; set; }
        }

        public class NumPurchases
        {
            [DefaultValue(null)]
            [JsonProperty("type")]
            public AttributesMetaModel.DataType type { get; set; }
            [DefaultValue(null)]
            [JsonProperty("inclusion")]
            public IList<int> inclusion { get; set; }
            [DefaultValue(null)]
            [JsonProperty("exclusion")]
            public IList<int> exclusion { get; set; }
            [DefaultValue(null)]
            [JsonProperty("numericality")]
            public AttributesMetaModel.Numericality numericality { get; set; }
        }

        public class NumDevices
        {
            [JsonProperty("delete")]
            public bool deleteThisAttribute { get; set; }
        }


        [JsonProperty("user_title")]
        public UserTitle user_title { get; set; }
        [JsonProperty("num_purchases")]
        public NumPurchases num_purchases { get; set; }
        [JsonProperty("num_devices")]
        public NumDevices num_devices { get; set; }
    }
}
