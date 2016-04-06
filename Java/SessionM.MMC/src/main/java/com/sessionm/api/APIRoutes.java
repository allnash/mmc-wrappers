package com.sessionm.api;

/**
 * Created by ngadre on 10/26/15.
 */
public class APIRoutes {


    public static String createUserRoute()
    {
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

    public static String createNewOrderForOfferWithExternalIdRoute(String offerId, String externalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + externalId + "/offers/" + offerId + "/orders";
    }

    public static String sendEventWithExternalIdRoute(String externalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + externalId + "/events";
    }

    public static String sendEventWithIdRoute(String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/events";
    }

    public static String createContentRoute()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/contents" ;
    }

    public static String fetchContentWithExternalId(String externalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/contents/" + externalId ;
    }

    public static String fetchContentWithId(String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/contents/" + Id ;
    }

    public static String updateContentWithExternalId(String externalId)
    {
        return fetchContentWithExternalId(externalId);
    }

    public static String updateContentWithId(String Id)
    {
        return fetchContentWithId(Id);
    }

    public static String fetchAllContentForUserWithExternalId(String externalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/users/" + externalId + "/contents";
    }

    public static String fetchAllContentForUserWithId(String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/users/" + Id + "/contents";
    }

    public static String fetchAllContentFeeds()
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/feeds";
    }

    public static String fetchContentFeedWithExternalId(String externalId)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/external/feeds/" + externalId;
    }

    public static String fetchContentFeedWithId(String Id)
    {
        return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + "/feeds/" + Id;
    }

}
