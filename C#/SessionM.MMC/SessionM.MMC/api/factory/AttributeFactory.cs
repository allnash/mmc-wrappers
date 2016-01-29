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
            SMResponse m = await AsyncClient.post(APIRoutes.addAttributesToUserModel(), createAddRequest);
            if (m == null) return false;
            if (m.model == null) { return false; } else { return true; }
        }

       
    }
}
