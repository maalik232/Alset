using AlsetMobileAttendence.Modal;
using AlsetMobileAttendence.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alset_Attendence_System.ViewModal
{
   public class ResetloginViewmodal : BaseViewModal
   {
        private string password;
        LoginService loginService;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Password)));
            }
        }


        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ConfirmPassword)));
            }
        }
        public ICommand ResetPaswordCommand { protected set; get; }

        public ResetloginViewmodal()
        {
            loginService = new LoginService();
            ResetPaswordCommand = new Command(resetPassword);
        }
        
        public async void resetPassword()
        {
            Loader = true;
            Login login = new Login {session = session,
                                      username = userEmail, 
                                      password = Password , 
                                      newPassword= Password
            };
            var response = await loginService.ResetPassword(login);
            Loader = false;
          
        }
    }
}
