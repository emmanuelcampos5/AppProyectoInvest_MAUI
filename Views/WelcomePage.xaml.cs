using AppProyectoInvest_MAUI.Controllers;

namespace AppProyectoInvest_MAUI.Views
{
    public partial class WelcomePage : ContentPage
    {
        private readonly WelcomeController _welcomeController;

        public WelcomePage()
        {
            InitializeComponent();

            // Crear una instancia del controlador
            _welcomeController = new WelcomeController();

            // Obtener el mensaje de bienvenida del controlador y mostrarlo
            var welcomeMessage = _welcomeController.GetWelcomeMessage();
            WelcomeMessageLabel.Text = welcomeMessage;
        }

        // M�todo para manejar el clic en el bot�n "Siguiente"
        private async void OnSiguienteClicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de UsuarioInfoView
            await Navigation.PushAsync(new UsuarioInfoView());
        }
    }
}
