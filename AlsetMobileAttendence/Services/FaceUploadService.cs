using AlsetMobileAttendence.Helper;
using AlsetMobileAttendence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlsetMobileAttendence.Services
{
    public class FaceUploadService
    {
        APIService apiService;
        public FaceUploadService()
        {
            apiService = new APIService();
        }

        public async Task<Face> uploadFace(Face face)
        {
            var resObj = await apiService.makeAPICall<Face>(face, Constents.FaceURL.GeneratePresigned);

            if (resObj != null)
            {
                //Preferences.Set("LOGINUSER", JsonConvert.SerializeObject(resObj));
                return resObj;
            }

            return resObj;
        }


        public async Task<object> uploadFaceForURL(object face ,string url)
        {
            var resObj = await apiService.makeAPICallForUpdate<object>(face, url);

            if (resObj != null)
            {
                //Preferences.Set("LOGINUSER", JsonConvert.SerializeObject(resObj));
                return resObj;
            }

            return resObj;

        }

    }
}
