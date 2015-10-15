using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using SessionM.MMC;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace SessionM.MMC.API.factory
{
    public class UserFactory
    {
        public enum UserGender
        {
            m, f
        }

        public static async Task<User> createUser(string externalId, String email, UserGender gender, String dob, String ipAddress)
        {
            IPAddress address;
            if (!IPAddress.TryParse(ipAddress, out address))
            {
                Console.Write("UserFactory - Create User - Invalid IP - " + ipAddress);
                return null;
            }

            var myUser = new User
            {
                external_id = externalId,
                email = email,
                dob = dob,
                gender = gender.ToString("g"),
                ip = ipAddress

            };

            SMRequest createUserRequest = new SMRequest();
            createUserRequest.user = myUser;
            string json = JsonConvert.SerializeObject(createUserRequest,Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.post(APIRoutes.createUserRoute(), json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.user;
        }


        public static async Task<User> getUserByExternalId(string externalId)
        {
            string responseString = await AsyncClient.get(APIRoutes.fetchUserWithExternalIdRoute() + externalId);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.user;
        }

        public static async Task<User> getUserById(string id)
        {
            string responseString = await AsyncClient.get(APIRoutes.fetchUserWithIdRoute() + id);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.user;
        }

        public static async Task<bool> deleteUserByExternalId(string externalId)
        {
            string responseString = await AsyncClient.delete(APIRoutes.deleteUserUserWithExternalIdRoute() + externalId);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return false;
            if (m.user == null) return false; else return true;
        }

        public static async Task<bool> deleteUserById(string id)
        {

            string responseString = await AsyncClient.delete(APIRoutes.deleteUserWithIdRoute() + id);
            SMResponse r = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (r == null) return false;
            if (r.user == null) return false; else return true;
        }

        public static async Task<User> updateUserProfileById(string id, Dictionary<string, string> meta)
        {


            var myUser = new User
            {
                user_profile = meta
            };

            SMRequest createUserRequest = new SMRequest();
            createUserRequest.user = myUser;
            string json = JsonConvert.SerializeObject(createUserRequest, Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            string responseString = await AsyncClient.put(APIRoutes.updateUserWithId() + id, json);
            SMResponse m = JsonConvert.DeserializeObject<SMResponse>(responseString);
            if (m == null) return null;
            return m.user;
        }
    }
}
