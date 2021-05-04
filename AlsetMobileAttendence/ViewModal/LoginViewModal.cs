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
    public class LoginViewModal : BaseViewModal
    {

        public Action RedirectPasswordResetPage,LoginSuccess, RedirectLogin;
        LoginService loginService;

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Email)));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public ICommand LoginCommand { protected set; get; }
       
        public LoginViewModal()
        {
            LoginCommand = new Command(OnSubmit);
            loginService = new LoginService();
           
        }

        public async void OnSubmit()
        {
            Loader = true;
            var response = await login();
            
            if (response.session != null)
            {
                session = response.session;
                RedirectPasswordResetPage();
            }
            else
            {
                AskConfirmPassword = false;
                LoginSuccess();
            }
            Loader = false;
        }

        public async Task<Login> login()
        {
        
            userEmail = Email;
            Login login = new Login { username = Email, password = Password };
            var response=  await loginService.Login(login);


            return response;
        }


    }
}
