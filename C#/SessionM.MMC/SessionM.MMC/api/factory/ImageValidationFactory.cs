using SessionM.MMC.JsonService;
using SessionM.MMC.models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SessionM.MMC.API.factory
{
    public class ImageValidationFactory
    {
        public static async Task<ImageValidation> validateImage(User user, ImageValidation img)
        {
            SMRequest imageValidationRequest = new SMRequest();
            imageValidationRequest.user = user;
            imageValidationRequest.imageValidation = img;

            string route = String.IsNullOrEmpty(user.id) ? APIRoutes.validateImageWithUserIdRoute(user.id) :
                                                           APIRoutes.validateImageWithExternalIdRoute(user.external_id);
           
            SMResponse m = await AsyncClient.post(route, imageValidationRequest);
            return m == null ? null : m.GetImageValidationModel();
        }

        public static async Task<IList<ImageValidation>> getImages(User user)
        {
            string route = String.IsNullOrEmpty(user.id) ? APIRoutes.validateImageWithUserIdRoute(user.id) :
                                                           APIRoutes.validateImageWithExternalIdRoute(user.external_id);

            SMResponse m = await AsyncClient.get(route);

            //note that this is a list of imagevalidation objects
            return m == null ? null : m.imageValidations;
        }
    }
}
