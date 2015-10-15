using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.models
{
    public class AttributesMetaModel
    {
        public class Length
        {
            [DefaultValue(0)]
            [JsonProperty("minimum")]
            public int minimum { get; set; }
            [DefaultValue(0)]
            [JsonProperty("maximum")]
            public int maximum { get; set; }
        }


        public class Numericality
        {
            [DefaultValue(0)]
            [JsonProperty("greater_than")]
            public int greater_than { get; set; }
            [DefaultValue(0)]
            [JsonProperty("greater_than_or_equal_to")]
            public int greater_than_or_equal_to { get; set; }
            [DefaultValue(0)]
            [JsonProperty("less_than")]
            public int less_than { get; set; }
            [DefaultValue(0)]
            [JsonProperty("less_than_or_equal_to")]
            public int less_than_or_equal_to { get; set; }
            [DefaultValue(null)]
            [JsonProperty("even")]
            public bool even { get; set; }
            [DefaultValue(null)]
            [JsonProperty("odd")]
            public bool odd { get; set; }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Filters
        {
            downcase, upcase, strip, rstrip, lstrip
        }

        [JsonConverter(typeof(DataTypeConverter))]
        public sealed class DataType
        {

            private readonly String name;
            private readonly int value;

            public static readonly DataType STRING = new DataType(1, "string");
            public static readonly DataType INTEGER = new DataType(2, "integer");
            public static readonly DataType BOOLEAN = new DataType(2, "boolean");

            private DataType(int value, String name)
            {
                this.name = name;
                this.value = value;
            }

            public static DataType ofValue(String name)
            {
                DataType d;
                switch (name)
                {
                    case "string":
                        d = DataType.STRING;
                        break;
	                case "integer":
                        d = DataType.INTEGER;      
		                break;
	                case "boolean":
                        d = DataType.BOOLEAN;
                        break;
                    default:
                        d = null;
                        break;
                }
                return d;
            }

            public override String ToString()
            {
                return name;
            }

        }

        public class DataTypeConverter : JsonConverter
        {
             public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
             {
                 DataType dataType = (DataType)value;
     
                 writer.WriteValue(dataType.ToString());
             }
     
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                DataType dataType = DataType.ofValue((string)reader.Value);
                return dataType;
            }
    
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(User);
            }
        }
    }

    
}
