package com.sessionm.api;

import com.typesafe.config.Config;
import com.typesafe.config.ConfigFactory;

/**
 * Created by ngadre on 10/26/15.
 */
public class APIConstants {

    private static String API_KEY = null;
    private static String S2S_API_SECRET = null;
    private static String API_VERSION = "v1";

    public static Config SESSIONM_LIBRARY_CONFIG;

    private static void loadConfigs() {
        if(SESSIONM_LIBRARY_CONFIG == null)
            SESSIONM_LIBRARY_CONFIG = ConfigFactory.load("SMServiceConfig");
    }

    public static String serviceUrl() {
        loadConfigs();
        return "https://"+ SESSIONM_LIBRARY_CONFIG.getString("sessionm.api_host") + "/priv/" + getApiVersion();
    }

    public static String getApiVersion()
    {
        return API_VERSION;
    }

    public static void setCredentials(String api_key, String s2s_api_secret) {
        API_KEY = api_key;
        S2S_API_SECRET = s2s_api_secret;
    }

    static String getCredentials() {
        loadConfigs();
        if (API_KEY == null || S2S_API_SECRET == null) {
            API_KEY = SESSIONM_LIBRARY_CONFIG.getString("sessionm.property.api_key");
            S2S_API_SECRET = SESSIONM_LIBRARY_CONFIG.getString("sessionm.property.secret");
        }
        return API_KEY + ":" + S2S_API_SECRET;
    }

    static String getApiKey()
    {
        loadConfigs();

        if (API_KEY == null || S2S_API_SECRET == null)
        {
            API_KEY = SESSIONM_LIBRARY_CONFIG.getString("sessionm.property.api_key");
            S2S_API_SECRET = SESSIONM_LIBRARY_CONFIG.getString("sessionm.property.secret");
        }
        return API_KEY;
    }

}
