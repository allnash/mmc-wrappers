using System;

namespace SessionM.MMC.API
{
    public class APIConstants
    {

        private static String API_KEY = null;
        private static String S2S_API_SECRET = null;
        private static String API_VERSION = "v1";

        public static String serviceUrl() {
            return SMServiceConfig.Instance.ServerUrl + "/priv/" + getApiVersion();
        }

        public static String getApiVersion()
        {
            return API_VERSION;
        }
        
        public static void setCredentials(String api_key, String s2s_api_secret) {
            API_KEY = api_key;
            S2S_API_SECRET = s2s_api_secret;
        }

        internal static String getCredentials() {
            if (API_KEY == null || S2S_API_SECRET == null) {
                API_KEY = SMServiceConfig.Instance.ApiKey;
                S2S_API_SECRET = SMServiceConfig.Instance.ApiSecret;
            }
            return API_KEY + ":" + S2S_API_SECRET;
        }

        internal static String getApiKey()
        {
            return API_KEY;
        }

    }
}
