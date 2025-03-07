using Encuestas.Models.Models;
using Encuestas.ClientServices.Services;
using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core.Debug;
using Microsoft.Extensions.Logging;
using OneSignalSDK.DotNet.Core.Notifications;
using OneSignalSDK.DotNet.Core.InAppMessages;

namespace EncuestasMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            OneSignal.Debug.LogLevel = OneSignalSDK.DotNet.Core.Debug.LogLevel.VERBOSE;
            //OneSignal.Debug.LogLevel = OneSignalSDK.DotNet.Core.Debug.LogLevel.INFO;
            OneSignal.Debug.AlertLevel = OneSignalSDK.DotNet.Core.Debug.LogLevel.FATAL;

            OneSignal.Initialize("a0d8baa5-b287-4cfd-a465-2c6c872c5535");
            OneSignal.ConsentRequired = true;

            try
            {
                OneSignal.Notifications.RequestPermissionAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al solicitar permisos de notificación: {ex.Message}");
            }

            OneSignal.Notifications.WillDisplay += OnNotificationWillDisplay;
        }

        private void OnNotificationWillDisplay(object sender, NotificationWillDisplayEventArgs e)
        {
            // Handle notification display events (optional customizations)
            //Shell.Current.DisplayAlert("notification", "notification", "ok");
            Console.WriteLine("evento 1");
        }


        /*

        OneSignal.Notifications.WillDisplay += OnNotificationWillDisplay;
        OneSignal.InAppMessages.WillDisplay += InAppMessageWillDisplay;
    }


    private void InAppMessageWillDisplay(object sender, InAppMessageWillDisplayEventArgs e)
    {
        // Handle in-app message display events
        Console.WriteLine("evento 2");
    }

        */
        /*
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
        */

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
