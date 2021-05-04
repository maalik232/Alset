using AlsetMobileAttendence.Modal;
using AlsetMobileAttendence.Services;
using AlsetMobileAttendence.ViewModal;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlsetMobileAttendence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : ContentPage
    {
        DashBoardViewModal dashBoardViewModal = new DashBoardViewModal();
        FaceUploadService faceUploadService;

        public DashBoard()
        {
            BindingContext = dashBoardViewModal;
            InitializeComponent();
            faceUploadService = new FaceUploadService();
        }
        bool vissible = true;
        private async void takePhoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }
            Random rnd = new Random();
            string name = "test" + rnd.Next(1, 100) + ".jpg";
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = name
            });


            var image = new Image
            {
                Source = ImageSource.FromFile(file.Path)
            };

            if (file == null)
                return;

            loader.IsVisible = true;
            loader.IsRunning = true;
            Face face = new Face { bucket = "student-faces-source", fileName = name };
            var ff= await faceUploadService.uploadFace(face);
            var bytestrwam = ReadFully(file.GetStream());


             faceUploadService.uploadFaceForURL(bytestrwam, ff.URL);

            var images = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

     
           await DisplayAlert("Status", "Your attendence is marked", "OK");

            

           
            loader.IsVisible = false;
            loader.IsRunning = false;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedItem != null)
            {
                Modal.Modules tappedModule = (Modal.Modules)picker.SelectedItem;
                dashBoardViewModal.FilterClasses(tappedModule.module_id);
            }

        }
    }
}