using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core.Debug;

namespace EncuestasMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            OneSignal.Debug.LogLevel = LogLevel.VERBOSE;
            OneSignal.Initialize("a0d8baa5-b287-4cfd-a465-2c6c872c5535");

            //solicita los permisos al usuario
            OneSignal.Notifications.RequestPermissionAsync(true);
            

            MainPage = new AppShell();
        }
    }
}
