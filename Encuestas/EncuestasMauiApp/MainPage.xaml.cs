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
            /*
            // Enable verbose OneSignal logging to debug issues if needed.
            OneSignal.Debug.LogLevel = LogLevel.VERBOSE;

            //OneSignal.ConsentRequired = true;

            // OneSignal Initialization
            OneSignal.Initialize("a0d8baa5-b287-4cfd-a465-2c6c872c5535");
            */
            // RequestPermissionAsync will show the notification permission prompt.
            // We recommend removing the following code and instead using an In-App Message to prompt for notification permission (See step 5)
            /*

            try
            {
                OneSignal.Notifications.RequestPermissionAsync(true);
            }
            catch (Exception ex)
            {
                // Manejar el error, por ejemplo, registrándolo o mostrando un mensaje al usuario.
                Console.WriteLine($"Error al solicitar permisos de notificación: {ex.Message}");
            }

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.PostNotifications) != Permission.Granted)
            { 

            }*/
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
