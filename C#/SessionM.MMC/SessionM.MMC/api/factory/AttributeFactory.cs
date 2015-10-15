using Newtonsoft.Json;
using SessionM.MMC.JsonService;
using SessionM.MMC.models.attributes;
using System.Threading.Tasks;

namespace SessionM.MMC.API.factory
{
    public class AttributeFactory
    {
        public static async Task<bool> addToUserModel(IAttributes attributes)
        {
            SMRequest createAddRequest = new SMRequest();
            createAddRequest.attributes = attributes;
            string json = JsonConvert.SerializeObject(createAddRequest, Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, });
            string responseString = await AsyncClient.post(APIRoutes.addAttributesToUserModel(), json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return false;
            if (m.model == null) { return false; } else { return true; }
        }

       
    }
}
