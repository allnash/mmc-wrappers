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
            await AsyncClient.post(API.APIRoutes.sendEventWithExternalIdRoute(externalId), createUserRequest);
            return true;
        }

        public static async Task<bool> sendEventById(string Id, IEvents events)
        {
            
            SMRequest createUserRequest = new SMRequest();
            createUserRequest.autoClaim = true;
            createUserRequest.events = events;
            await AsyncClient.post(API.APIRoutes.sendEventWithIdRoute(Id), createUserRequest);
            return true;
        }
    }
}
