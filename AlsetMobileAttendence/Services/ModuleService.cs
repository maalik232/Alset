using AlsetMobileAttendence.Helper;
using AlsetMobileAttendence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlsetMobileAttendence.Services
{
    public class ModuleService
    {
        APIService apiService;
        public ModuleService()
        {
            apiService = new APIService();
        }

        public async Task<List<TimeSlot>> GetClasses()
        {
            var resObj = await apiService.getDataList<List<TimeSlot>>(Constents.ClassesURL.GetClasses);

            if (resObj != null)
            {
                //Preferences.Set("LOGINUSER", JsonConvert.SerializeObject(resObj));
                return resObj;
            }

            return resObj;

        }

        public async Task<List<Modules>> GetModules()
        {
            var resObj = await apiService.getDataList<List<Modules>>(Constents.ModulesURL.GetModules);

            if (resObj != null)
            {
                //Preferences.Set("LOGINUSER", JsonConvert.SerializeObject(resObj));
                return resObj;
            }

            return resObj;

        }



    }
}
