using Newtonsoft.Json;
using SessionM.MMC.JsonService;
using SessionM.MMC.models.intefaces;
using System.Threading.Tasks;

namespace SessionM.MMC.API.factory
{
    public class EventFactory
    {
        public static async Task<bool> sendEventByExternalId(string externalId, IEvents events)
        {

            SMRequest createUserRequest = new SMRequest();
            createUserRequest.autoClaim = true;
            createUserRequest.events = events;
            string json = JsonConvert.SerializeObject(createUserRequest, Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.post(API.APIRoutes.sendEventWithExternalIdRoute(externalId), json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return true;
        }

        public static async Task<bool> sendEventById(string Id, IEvents events)
        {
            
            SMRequest createUserRequest = new SMRequest();
            createUserRequest.autoClaim = true;
            createUserRequest.events = events;
            string json = JsonConvert.SerializeObject(createUserRequest, Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.post(API.APIRoutes.sendEventWithIdRoute(Id), json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return true;
        }
    }
}
