using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;
using System.Net;
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
            SMResponse m = await AsyncClient.post(APIRoutes.createUserRoute(), createUserRequest);
            if (m == null) return null;
            return m.user;
        }


        public static async Task<User> getUserByExternalId(string externalId)
        {
            SMResponse m = await AsyncClient.get(APIRoutes.fetchUserWithExternalIdRoute() + externalId);
            if (m == null) return null;
            return m.user;
        }

        public static async Task<User> getUserById(string id)
        {
            SMResponse m = await AsyncClient.get(APIRoutes.fetchUserWithIdRoute() + id);
            if (m == null) return null;
            return m.user;
        }

        public static async Task<bool> deleteUserByExternalId(string externalId)
        {
            SMResponse m = await AsyncClient.delete(APIRoutes.deleteUserUserWithExternalIdRoute() + externalId);
            if (m == null) return false;
            if (m.user == null) return false; else return true;
        }

        public static async Task<bool> deleteUserById(string id)
        {

            SMResponse r = await AsyncClient.delete(APIRoutes.deleteUserWithIdRoute() + id);
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
            SMResponse m = await AsyncClient.put(APIRoutes.updateUserWithId() + id, createUserRequest);
            if (m == null) return null;
            return m.GetUserResponseModel();
        }

        public static async Task<Verification> validateViaSMS(User user)
        {
            //sending only the data we need
            User tempUser = new User();
            tempUser.id = user.id;
            tempUser.phoneNumber = user.phoneNumber;
            tempUser.message = user.message;

            string route = !String.IsNullOrEmpty(tempUser.id) ? APIRoutes.sendSMSWithLinkWithUserIdRoute(tempUser.id) : 
                                                                APIRoutes.sendSMSWithLinkWithExternalIdRoute(tempUser.external_id);

            SMResponse m = await AsyncClient.post(route, ConstructSMRequest(tempUser));

            return m == null ? null : m.GetVerificationResponseModel();

        }

        public static async Task<Verification> validateSMSVerificationCode(User user, Verification verification)
        {
            User tempUser = new User();
            tempUser.id = user.id;

            string route = !String.IsNullOrEmpty(tempUser.id) ? APIRoutes.validateVerificationIdWithUserIdRoute(tempUser.id, verification.id.ToString()) :
                                                                APIRoutes.validateVerificationIdWithExternalIdRoute(tempUser.external_id, verification.id.ToString());

            SMResponse m = await AsyncClient.post(route, ConstructSMRequest(verification));
            return m == null ? null : m.GetVerificationResponseModel();

        }

        public static async Task<Verification> validateSMSVerificationCode(User user)
        {
            User tempUser = new User();
            tempUser.id = user.id;

            string route = !String.IsNullOrEmpty(tempUser.id) ? APIRoutes.validateActivationCodeWithUserIdRoute(tempUser.id) :
                                                                APIRoutes.validateActivationCodeWithExternalIdRoute(tempUser.external_id);

            SMResponse m = await AsyncClient.post(route, ConstructSMRequest(tempUser));
            return m == null ? null : m.GetVerificationResponseModel();
        }

        public static async Task<User> addUserMetaDataByUserId(User user, Dictionary<string, string> metaData)
        {
            User tempUser = new User();
            tempUser.id = user.id;
            tempUser.external_id = user.external_id;
            tempUser.meta = metaData;

            string route = !String.IsNullOrEmpty(tempUser.id) ? APIRoutes.addUserMetaDataWithUserIdRoute(tempUser.id) :
                                                                APIRoutes.addUserMetaDataWithExternalIdRoute(tempUser.external_id);

            SMResponse m = await AsyncClient.post(route, ConstructSMRequest(tempUser));
            return m == null ? null : m.user;
        }

        public static async Task<User> addProxyId(string externalId, string proxyIdToRegister)
        {
            User user = new User();
            user.external_id = externalId;
            ProxyId proxyId = new ProxyId();
            proxyId.register = proxyIdToRegister;
            user.proxyId = proxyId;

            string route = APIRoutes.addRemoveProxyIdWithExternalIdRoute(externalId);
            SMResponse m = await AsyncClient.put(route, ConstructSMRequest(user));
            return m == null ? null : m.user;
        }

        public static async Task<User> removeProxyId(string externalId, string proxyIdToUnregister)
        {
            User user = new User();
            user.external_id = externalId;
            ProxyId proxyId = new ProxyId();
            proxyId.unregister = proxyIdToUnregister;
            user.proxyId = proxyId;
            
            string route = APIRoutes.addRemoveProxyIdWithExternalIdRoute(externalId);
            SMResponse m = await AsyncClient.put(route, ConstructSMRequest(user));
            return m == null ? null : m.user;
        }

        public static async Task<User> getPointHistory(User user, string startDate, string endDate, Nullable<int> limit, string cursor)
        {
            User tempUser = new User();
            tempUser.id = user.id;

            string route = !String.IsNullOrEmpty(tempUser.id) ? APIRoutes.pointHistoryWithUserIdRoute(tempUser.id, startDate, endDate, limit, cursor) :
                                                                APIRoutes.pointHistoryWithExternalIdRoute(tempUser.external_id, startDate, endDate, limit, cursor);

            SMResponse m = await AsyncClient.get(route);
            return m == null ? null : m.GetUserResponseModel();
        }

        private static SMRequest ConstructSMRequest(User user)
        {
            SMRequest request = new SMRequest();
            request.user = user;

            return request;
        }

        private static SMRequest ConstructSMRequest(Verification verification)
        {
            SMRequest request = new SMRequest();
            request.verification = verification;

            return request;
        }
    }
}
