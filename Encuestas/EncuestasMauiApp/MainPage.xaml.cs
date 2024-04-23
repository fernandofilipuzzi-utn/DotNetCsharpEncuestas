using Encuestas.Models.Models;
using Encuestas.ClientServices.Services;
using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core.Debug;

namespace EncuestasMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            OneSignal.Debug.LogLevel = LogLevel.VERBOSE;


            OneSignal.Initialize("a0d8baa5-b287-4cfd-a465-2c6c872c5535");
            OneSignal.ConsentRequired = true;

            OneSignal.User.PushSubscription.Changed += (sender, e) =>
            {
                if (e.State.Current.Id != e.State.Previous.Id)
                {
                    // OneSignal Subscription id changed.
                    Shell.Current.DisplayAlert("push", "changed", "ok");
                }
            };

            OneSignal.Notifications.Clicked += (sender, e) =>
            {
                // Access the notification with e.Notification and the click result with e.Result
                Shell.Current.DisplayAlert("notification", "notification", "ok");
            };

            OneSignal.Notifications.WillDisplay += (sender, e) =>
            {
                // Prevent OneSignal from displaying the notification immediately on return.
                e.PreventDefault();

                // Do some async work

                Shell.Current.DisplayAlert("willdisplay", "willdisplay", "ok");

                // Display the notification after some async work
                //e.Notification.Display();
            };

            OneSignal.InAppMessages.WillDisplay += (sender, e) =>
            {
                Shell.Current.DisplayAlert("inwilldisplay", "inwilldisplay", "ok");
            };
        }

        private async void btnPrueba_Clicked(System.Object sender, System.EventArgs e)
        {
            EncuestasService servicio = new EncuestasService();
            var encuesta = await servicio.Prueba();
            if (encuesta != null)
            {
                lbnRespuesta.Text = encuesta.Nombre;
            }
            else
            {
                lbnRespuesta.Text = "-";
            }
            
            if (OneSignal.Notifications.Permission)
            {
                await Shell.Current.DisplayAlert("permisos", "tiene !", "ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("permisos", "no tiene", "ok");
            }
        }
    }
}
