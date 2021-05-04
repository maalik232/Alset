using AlsetMobileAttendence.Helper;
using AlsetMobileAttendence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlsetMobileAttendence.Services
{
    public class LoginService
    {
        APIService apiService;
        public LoginService()
        {
            apiService = new APIService();
        }



        public async Task<Login> Login(Login login)
        {
            var resObj = await apiService.makeAPICall<Login>(login,Constents.LoginURL.Login);

            if (resObj != null)
            {
                //Preferences.Set("LOGINUSER", JsonConvert.SerializeObject(resObj));
                return resObj;
            }

            return resObj;

        }

        public async Task<Login> ResetPassword(Login login)
        {
            var resObj = await apiService.makeAPICall<Login>(login,Constents.LoginURL.ResetPassword);

            if (resObj != null)
            {
                //Preferences.Set("LOGINUSER", JsonConvert.SerializeObject(resObj));
                return resObj;
            }

            return resObj;

        }

    }
}
