using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionM.MMC.API
{
    public class APIRoutes
    {
        private static string ConstructRoute(string suffix)
        {
            return APIConstants.serviceUrl() + "/apps/" + APIConstants.getApiKey() + suffix;
        }

        public static string createUserRoute() {
            return ConstructRoute("/users");
        }
        
        public static string fetchUserWithIdRoute()
        {
            return ConstructRoute("/users/");
        }

        public static string fetchUserWithExternalIdRoute()
        {
            return ConstructRoute("/external/users/");
        }

        public static string deleteUserWithIdRoute()
        {
            return fetchUserWithIdRoute();
        }

        public static string deleteUserUserWithExternalIdRoute()
        {
            return fetchUserWithExternalIdRoute();
        }


        public static string updateUserWithId()
        {
            return fetchUserWithIdRoute();
        }


        public static string addAttributesToUserModel()
        {
            return ConstructRoute("/models/user_profiles/attributes");
        }

        public static string fetchCurrentAttributesInUserModel()
        {
            return ConstructRoute("/models/user_profiles");
        }


        public static string fetchOffersRoute(string locale = null)
        {

            return ConstructRoute("/offers") +
                    (String.IsNullOrEmpty(locale) ? String.Empty : ("?locale=" + locale));
        }

        public static string fetchOffersWithIdRoute(String Id, string locale = null)
        {

            return ConstructRoute("/users/" + Id + "/offers") +
                    (String.IsNullOrEmpty(locale) ? String.Empty : ("?locale=" + locale));
        }

        public static string fetchOffersWithExternalIdRoute(String ExternalId, string locale = null)
        {
            
            return ConstructRoute("/external/users/" + ExternalId + "/offers") +
                    (String.IsNullOrEmpty(locale) ? String.Empty : ("?locale=" + locale));
        }

        public static string createNewOrderForOfferWithIdRoute(String offerId, String Id)
        {
            return ConstructRoute("/users/" + Id + "/offers/" + offerId + "/orders");
        }

        public static string createNewOrderForOfferWithExternalIdRoute(String offerId, String ExternalId)
        {
            return ConstructRoute("/external/users/" + ExternalId + "/offers/" + offerId + "/orders");
        }

        public static string sendEventWithExternalIdRoute(String ExternalId)
        {
            return ConstructRoute("/external/users/" + ExternalId + "/events");
        }

        public static string sendEventWithIdRoute(String Id)
        {
            return ConstructRoute("/users/" + Id + "/events");
        }

        public static string sendSMSWithLinkWithUserIdRoute(String userId, bool prependExternal = false)
        {
            return ConstructRoute(String.Format("{0}/users/" + userId + "/verifications/sms", prependExternal ? "/external" : ""));
        }

        public static string sendSMSWithLinkWithExternalIdRoute(String externalId)
        {
            return sendSMSWithLinkWithUserIdRoute(externalId, true);
        }

        public static string validateActivationCodeWithUserIdRoute(string userId, string verificationId)
        {
            return sendSMSWithLinkWithUserIdRoute(userId) + "/" + verificationId;
        }

        public static string validateActivationCodeWithExternalIdRoute(string externalId, string verificationId)
        {
            return sendSMSWithLinkWithUserIdRoute(externalId, true) + "/" + verificationId;
        }

        public static string validateActivationCodeWithUserIdRoute(string userId)
        {
            return validateActivationCodeWithUserIdRoute(userId, "verifycode");
        }

        public static string validateActivationCodeWithExternalIdRoute(string userId)
        {
            return validateActivationCodeWithExternalIdRoute(userId, "verifycode");
        }

        public static string addUserMetaDataWithUserIdRoute(string userId, bool prependExternal = false)
        {
            return ConstructRoute(String.Format("{0}/users/" + userId + "/data", prependExternal ? "/external" : ""));
        }

        public static string addUserMetaDataWithExternalIdRoute(String externalId)
        {
            return addUserMetaDataWithUserIdRoute(externalId, true);
        }

        public static string validateImageWithUserIdRoute(string userId, bool prependExternal = false)
        {
            return ConstructRoute(String.Format("{0}/users/" + userId + "/image_validations", prependExternal ? "/external" : ""));
        }

        public static string validateImageWithExternalIdRoute(string externalId)
        {
            return validateImageWithUserIdRoute(externalId, true);
        }

        public static string challengeQuestionWithUserIdRoute(string userId, bool prependExternal = false)
        {
            return ConstructRoute(String.Format("{0}/users/" + userId + "/challenges/skills_test_question", prependExternal ? "/external" : ""));
        }

        public static string challengeQuestionWithExternalIdRoute(string externalId)
        {
            return challengeQuestionWithUserIdRoute(externalId, true);
        }

        public static string pointHistoryWithUserIdRoute(string userId, string startDate, string endDate, Nullable<int> limit, string cursor, bool prependExternal = false)
        {
            string retVal = ConstructRoute(String.Format("{0}/users/" + userId + "/points/transactions", prependExternal ? "/external" : ""));
            List<string> getLineArgs = new List<string>();

            if (startDate != null)
            {
                getLineArgs.Add("start_date=" + startDate);
            }

            if (endDate != null)
            {
                getLineArgs.Add("end_date=" + endDate);
            }

            if (limit != null)
            {
                getLineArgs.Add("limit=" + limit);
            }

            if (cursor != null)
            {
                getLineArgs.Add("cursor=" + cursor);
            }

            retVal = getLineArgs.Count <= 0 ? retVal : (retVal + "?" + String.Join("&", getLineArgs.ToArray()));

            return retVal;
        }

        public static string pointHistoryWithExternalIdRoute(string externalId, string startDate, string endDate, Nullable<int> limit, string cursor)
        {
            return pointHistoryWithUserIdRoute(externalId, startDate, endDate, limit, cursor, true);
        }

        public static string challengeAnswerSubmissionWithUserIdRoute(string userId, int skillsTestQuestionId, int offerId, bool prependExternal = false)
        {
            return ConstructRoute(String.Format("{0}/users/" + userId + "/offers/" + offerId + "/challenges/skills_test_questions/" + skillsTestQuestionId, prependExternal ? "/external" : ""));
        }

        public static string challengeAnswerSubmissionWithExternalIdRoute(string externalId, int skillsTestQuestionId, int offerId)
        {
            return challengeAnswerSubmissionWithUserIdRoute(externalId, skillsTestQuestionId, offerId, true);
        }

        public static string validateVerificationIdWithUserIdRoute(string userId, string verificationId, bool prependExternal = false)
        {
            return ConstructRoute(String.Format("{0}/users/" + userId + "/verifications/sms/" + verificationId, prependExternal ? "/external" : ""));
        }

        public static string validateVerificationIdWithExternalIdRoute(string externalId, string verificationId)
        {
            return validateVerificationIdWithUserIdRoute(externalId, verificationId, true);
        }

        public static string addProxyIdWithExternalIdRoute(string externalId)
        {
            return ConstructRoute("/external/users/" + externalId);
        }

        public static string addRemoveProxyIdWithExternalIdRoute(string externalId)
        {
            return ConstructRoute("/external/users/" + externalId);
        }

        
       
    }
}
