using System;
using System.Linq;
using System.Threading.Tasks;
using SessionM.MMC.API;
using SessionM.MMC.API.factory;
using SessionM.MMC.models;
using SessionM.MMC.models.events;
using System.Collections.Generic;

namespace SessionM.MMC.TestApp
{
    class Program
    {

        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            Console.Write("CREATE USER");
            SMServiceConfig.Instance.Refresh();
            User testUser;
            DateTime value = new DateTime(1990, 1, 1);
            Task.Run(async () =>
            {
                // Create A User
                testUser = await UserFactory.createUser(generateID(), RandomString(6) + "@example.com", UserFactory.UserGender.f, value.ToString("yyyy-MM-dd"), "127.0.0.1");
                // Fetch User
                testUser = await UserFactory.getUserByExternalId(testUser.external_id);
                // When the User does Something Send an Event to SessionM Server
                Console.WriteLine("SEND BUY EVENT/EVENTS");
                var events = new ActivityEvents<String, int>();
                events.Add("buy_something", 1);
                bool added = await EventFactory.sendEventByExternalId(testUser.external_id, events);
                // Fetch User And Get Updated Points
                testUser = await UserFactory.getUserByExternalId(testUser.external_id);
                Console.WriteLine("USER POINTS : " + testUser.available_points);
                // Create an Order For the Rewards Offers
                Console.WriteLine("FETCH ALL OFFERS");
                List<Offer> allOffers = new List<Offer>(await OfferFactory.getAllOffers());
                Console.WriteLine("CREATE A NEW ORDER");
                Order myOrder1 = await OrderFactory.createOrderByExternalId(allOffers.First().id.ToString(), "127.0.0.1", testUser.external_id);
                // Fetch User And Get Updated Points
                testUser = await UserFactory.getUserByExternalId(testUser.external_id);
                Console.WriteLine("USER POINTS : " + testUser.available_points);

            }).Wait();
         
        }

    }
}
