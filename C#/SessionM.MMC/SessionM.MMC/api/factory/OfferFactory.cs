using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SessionM.MMC.API.factory
{
    public class OfferFactory
    {
        public static async Task<IList<Offer>> getAllOffersByExternalId(String externalId, string locale = null)
        {
            SMRequest offerRequest = new SMRequest();
            SMResponse m = await AsyncClient.get(APIRoutes.fetchOffersWithExternalIdRoute(externalId));
            if (m == null) return null;
            return m.offers;
        }

        public static async Task<IList<Offer>> getAllOffersById(String Id, string locale = null)
        {

            SMRequest offerRequest = new SMRequest();
            SMResponse m = await AsyncClient.get(APIRoutes.fetchOffersWithIdRoute(Id));
            if (m == null) return null;
            return m.offers;
        }

        public static async Task<IList<Offer>> getAllOffers(string locale = null)
        {
            
            SMRequest offerRequest = new SMRequest();
            SMResponse m = await AsyncClient.get(APIRoutes.fetchOffersRoute());
            if (m == null) return null;
            return m.offers;
        }
    }
}
