package com.sessionm.api;

/**
 * Created by ngadre on 10/26/15.
 */
public class APIRoutes {


    public static String createUserRoute() {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users";
    }

    public static String fetchUserWithIdRoute()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/";
    }

    public static String fetchUserWithExternalIdRoute()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/";
    }

    public static String deleteUserWithIdRoute()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/";
    }

    public static String deleteUserUserWithExternalIdRoute()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/";
    }


    public static String updateUserWithId()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/";
    }


    public static String addAttributesToUserModel()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/models/user_profiles/attributes";
    }

    public static String fetchCurrentAttributesInUserModel()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/models/user_profiles";
    }


    public static String fetchOffersRoute()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/offers";
    }

    public static String fetchOffersWithIdRoute(String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/offers";
    }

    public static String fetchOffersWithExternalIdRoute(String ExternalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + ExternalId + "/offers";
    }

    public static String createNewOrderForOfferWithIdRoute(String offerId, String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/offers/" + offerId + "/orders";
    }

    public static String createNewOrderForOfferWithExternalIdRoute(String offerId, String ExternalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + ExternalId + "/offers/" + offerId + "/orders";
    }

    public static String sendEventWithExternalIdRoute(String ExternalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + ExternalId + "/events";
    }

    public static String sendEventWithIdRoute(String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/events";
    }
}
