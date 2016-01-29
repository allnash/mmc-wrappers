using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;
using System.Net;

namespace SessionM.MMC.API.factory
{
    public class OrderFactory
    {
        

        public static async Task<Order> createOrderByExternalId(String offerId, String ipAddress, String ExternalId)
        {
            IPAddress address;
            if (!IPAddress.TryParse(ipAddress, out address))
            {
                Console.WriteLine("UserFactory - Create User - Invalid IP - " + ipAddress);
                return null;
            }

            Order myOrder = new Order {
                quantity = 1,
                recaptcha_challenge_field = "",
                recaptcha_response_field = "",
                ip = ipAddress,
                email = ""
            };
            
            SMRequest newOrderRequest = new SMRequest();
            newOrderRequest.order = myOrder;
            SMResponse m = await AsyncClient.post(APIRoutes.createNewOrderForOfferWithExternalIdRoute(offerId,ExternalId), newOrderRequest);
            if (m == null) return null;
            return m.order;
        }

        public static async Task<Order> createOrderByExternalId(Offer offer, String ipAddress, String ExternalId)
        {
            IPAddress address;
            if (!IPAddress.TryParse(ipAddress, out address))
            {
                Console.WriteLine("UserFactory - Create User - Invalid IP - " + ipAddress);
                return null;
            }

            Order myOrder = new Order
            {
                quantity = 1,
                recaptcha_challenge_field = "",
                recaptcha_response_field = "",
                ip = ipAddress,
                email = ""
            };

            SMRequest newOrderRequest = new SMRequest();
            newOrderRequest.order = myOrder;
            SMResponse m = await AsyncClient.post(APIRoutes.createNewOrderForOfferWithExternalIdRoute(offer.id.ToString(), ExternalId), newOrderRequest);
            if (m == null) return null;
            return m.order;
        }

        public static async Task<Order> createOrderById(String offerId, String ipAddress, String Id)
        {

            IPAddress address;
            if (!IPAddress.TryParse(ipAddress, out address))
            {
                Console.WriteLine("UserFactory - Create User - Invalid IP - " + ipAddress);
                return null;
            }

            Order myOrder = new Order
            {
                quantity = 1,
                recaptcha_challenge_field = "",
                recaptcha_response_field = "",
                ip = ipAddress,
                email = ""
            };

            SMRequest newOrderRequest = new SMRequest();
            newOrderRequest.order = myOrder;
            SMResponse m = await AsyncClient.post(APIRoutes.createNewOrderForOfferWithIdRoute(offerId, Id), newOrderRequest);
            return m.order;
        }
        
    }
}
