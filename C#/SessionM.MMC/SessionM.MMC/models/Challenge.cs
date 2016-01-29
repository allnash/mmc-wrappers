using Newtonsoft.Json;
using SessionM.MMC.models.intefaces;
using System.ComponentModel;

namespace SessionM.MMC.models
{

    public class Challenge : ISMModel
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

        [DefaultValue(null)]
        [JsonProperty("skills_test_question")]
        public SkillTestQuestion skillsTestQuestion { get; set; }

        [DefaultValue(null)]
        public object errors { get; set; }

        public class SkillTestQuestion
        {
            public SkillTestQuestion(int id, string response)
            {
                this.id = id;
                this.response = response;
            }

            [DefaultValue(null)]
            [JsonProperty("id")]
            public int id { get; set; }

            [DefaultValue(null)]
            [JsonProperty("question")]
            public string question { get; set; }

            [DefaultValue(null)]
            [JsonProperty("response")]
            public string response { get; set; }
        }
    }

}
