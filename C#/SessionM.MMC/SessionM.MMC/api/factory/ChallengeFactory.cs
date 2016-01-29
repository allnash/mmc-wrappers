using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;

namespace SessionM.MMC.API.factory
{
    public class ChallengeFactory
    {
        
        public static async Task<Challenge> postChallengeQuestion(User user, Challenge challenge, int offerId)
        {
            string route = !String.IsNullOrEmpty(user.id) ? APIRoutes.challengeAnswerSubmissionWithUserIdRoute(user.id, challenge.skillsTestQuestion.id, offerId) :
                                                            APIRoutes.challengeAnswerSubmissionWithExternalIdRoute(user.external_id, challenge.skillsTestQuestion.id, offerId);
            SMResponse m = await AsyncClient.post(route, ConstructSMRequest(challenge));
            return m == null ? null : m.challenge;
        }

        public static async Task<Challenge> getChallengeQuestion(User user)
        {
            string route = !String.IsNullOrEmpty(user.id) ? APIRoutes.challengeQuestionWithUserIdRoute(user.id) :
                                                           APIRoutes.challengeQuestionWithExternalIdRoute(user.external_id);
            SMResponse m = await AsyncClient.get(route);
            return m == null ? null : m.challenge;
        }

        private static SMRequest ConstructSMRequest(Challenge challenge)
        {
            SMRequest retVal = new SMRequest();
            retVal.challenge = challenge;

            return retVal;
        }

        private static SMRequest ConstructSMRequest(User user)
        {
            SMRequest retVal = new SMRequest();
            retVal.user = user;

            return retVal;
        }
    }
}
