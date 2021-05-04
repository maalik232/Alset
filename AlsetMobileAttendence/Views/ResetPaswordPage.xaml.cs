using Alset_Attendence_System.ViewModal;
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
    public partial class ResetPaswordPage : ContentPage
    {
        ResetloginViewmodal resetloginViewmodal;
        public ResetPaswordPage()
        {
            resetloginViewmodal = new ResetloginViewmodal();
            BindingContext = resetloginViewmodal;
       
            InitializeComponent();
        }

        private void ResertPasword_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}