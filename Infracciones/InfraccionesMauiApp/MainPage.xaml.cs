using Infracciones.ClientServices.Services;

namespace InfraccionesMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnPrueba_Clicked(System.Object sender, System.EventArgs e)
        {
            InfraccionesService servicio = new InfraccionesService();
            var infraccion = await servicio.Prueba();
            if (infraccion != null)
            {
                lbnRespuesta.Text = infraccion.Nombre;
            }
            else
            {
                lbnRespuesta.Text = "-";
            }
        }
    }
}
