using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

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
            string json = JsonConvert.SerializeObject(newOrderRequest, Formatting.Indented,
              new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.post(APIRoutes.createNewOrderForOfferWithExternalIdRoute(offerId,ExternalId),json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
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
            string json = JsonConvert.SerializeObject(newOrderRequest, Formatting.Indented,
              new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.post(APIRoutes.createNewOrderForOfferWithExternalIdRoute(offer.id.ToString(), ExternalId), json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
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
            string json = JsonConvert.SerializeObject(newOrderRequest, Formatting.Indented,
              new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.post(APIRoutes.createNewOrderForOfferWithIdRoute(offerId, Id), json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            return m.order;
        }
        
    }
}
