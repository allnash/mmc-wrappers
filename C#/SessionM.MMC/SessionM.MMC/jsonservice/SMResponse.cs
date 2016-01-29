using Newtonsoft.Json;
using SessionM.MMC.models;
using SessionM.MMC.models.attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.JsonService
{
    public class Model
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("request_key")]
        public string request_key { get; set; }
        [JsonProperty("attributes")]
        public MyAttributesModel attributes { get; set; }
    }

    public class SMResponse
    {
        [DefaultValue(null)]
        [JsonProperty("status")]
        public string status { get; set; }
        [DefaultValue(null)]
        [JsonProperty("errors")]
        public object errors { get; set; }
        [DefaultValue(null)]
        [JsonProperty("user")]
        public User user { get; set; }
        [DefaultValue(null)]
        [JsonProperty("model")]
        public Model model { get; set; }
        [DefaultValue(null)]
        [JsonProperty("offers")]
        public IList<Offer> offers { get; set; }
        [DefaultValue(null)]
        [JsonProperty("order")]
        public Order order { get; set; }
        [DefaultValue(null)]
        [JsonProperty("verification")]
        public Verification verification { get; set; }

        [DefaultValue(null)]
        [JsonProperty("image_validation")]
        public ImageValidation imageValidation { get; set; }

        [DefaultValue(null)]
        [JsonProperty("challenge")]
        public Challenge challenge { get; set; }

        [DefaultValue(null)]
        [JsonProperty("cursor")]
        public string cursor { get; set; }

        [DefaultValue(null)]
        [JsonProperty("transactions")]
        public IList<UserTransactionItem> transactions { get; set; }

        [DefaultValue(null)]
        [JsonProperty("image_validations")]
        public IList<ImageValidation> imageValidations { get; set; }

        public Verification GetVerificationResponseModel()
        {
            Verification retVal = null;
            retVal = this.verification == null ? new Verification() : this.verification;
            retVal.error = this.errors;
            
            return retVal;
        }

        public User GetUserResponseModel()
        {
            User retVal = null;
            retVal = this.user == null ? new User() : this.user;
            retVal.error = this.errors;
            retVal.cursor = this.cursor;
            retVal.transactions = this.transactions;

            return retVal;
        }
        
        public ImageValidation GetImageValidationModel()
        {
            ImageValidation retVal = null;
            retVal = this.imageValidation == null ? new ImageValidation() : this.imageValidation;
            retVal.error = this.errors;
            
            return retVal;
        }

        public Challenge GetChallengeModel()
        {
            Challenge retVal = null;
            retVal = this.challenge == null ? new Challenge() : this.challenge;
            retVal.errors = this.errors;

            return retVal;
        }
    }
}
