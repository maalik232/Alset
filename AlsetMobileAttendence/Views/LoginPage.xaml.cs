using Alset_Attendence_System.ViewModal;
using AlsetMobileAttendence;
using AlsetMobileAttendence.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Alset_Attendence_System.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModal loginViewModal;
        public LoginPage()
        {
            loginViewModal = new LoginViewModal();
            BindingContext = loginViewModal;
            loginViewModal.LoginSuccess += () => loginSuccess();
            loginViewModal.RedirectPasswordResetPage += () => PasswordResetPage();
            InitializeComponent();
        }

        public void loginSuccess()
        {
            if (!BaseViewModal.AskConfirmPassword)
            {
                App.Current.MainPage = new Xamarin.Forms.NavigationPage(new DashBoard());
            }
           
        }

        public async void PasswordResetPage()
        {
           BaseViewModal.AskConfirmPassword = false;
           await Navigation.PushAsync(new ResetPaswordPage());
        }
    }
}