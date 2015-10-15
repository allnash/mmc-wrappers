using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.API
{
    public class APIRoutes
    {
        public static string createUserRoute() {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users";
        }
        
        public static string fetchUserWithIdRoute()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/";
        }

        public static string fetchUserWithExternalIdRoute()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/";
        }

        public static string deleteUserWithIdRoute()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/";
        }

        public static string deleteUserUserWithExternalIdRoute()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/";
        }


        public static string updateUserWithId()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/";
        }


        public static string addAttributesToUserModel()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/models/user_profiles/attributes";
        }

        public static string fetchCurrentAttributesInUserModel()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/models/user_profiles";
        }


        public static string fetchOffersRoute()
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/offers";
        }

        public static string fetchOffersWithIdRoute(String Id)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/offers";
        }

        public static string fetchOffersWithExternalIdRoute(String ExternalId)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + ExternalId + "/offers";
        }

        public static string createNewOrderForOfferWithIdRoute(String offerId, String Id)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/offers/" + offerId + "/orders";
        }

        public static string createNewOrderForOfferWithExternalIdRoute(String offerId, String ExternalId)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + ExternalId + "/offers/" + offerId + "/orders";
        }

        public static string sendEventWithExternalIdRoute(String ExternalId)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + ExternalId + "/events";
        }

        public static string sendEventWithIdRoute(String Id)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/events";
        }

    }
}
