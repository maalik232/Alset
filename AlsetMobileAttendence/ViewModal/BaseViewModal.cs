using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Alset_Attendence_System.ViewModal
{
    public class BaseViewModal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static bool AskConfirmPassword=true;
        public static string userEmail;
        public static string session;

        public bool IsNotConnected { get; set; }
        public static bool IsInternatAvailable;


        private bool loader;
        public bool Loader
        {
            get { return loader; }
            set
            {
                loader = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Loader)));
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
