using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SessionM.MMC.API.factory
{
    public class OfferFactory
    {
      
        public static async Task<IList<Offer>> getAllOffersByExternalId(String externalId)
        {
            SMRequest offerRequest = new SMRequest();
            string responseString = await AsyncClient.get(APIRoutes.fetchOffersWithExternalIdRoute(externalId));
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.offers;
        }

        public static async Task<IList<Offer>> getAllOffersById(String Id)
        {

            SMRequest offerRequest = new SMRequest();
            string responseString = await AsyncClient.get(APIRoutes.fetchOffersWithIdRoute(Id));
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.offers;
        }

        public static async Task<IList<Offer>> getAllOffers()
        {
            
            SMRequest offerRequest = new SMRequest();
            string responseString = await AsyncClient.get(APIRoutes.fetchOffersRoute());
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.offers;
        }
        
    }
}
