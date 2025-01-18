namespace AppProyectoInvest_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Establecemos WelcomePage como la página principal, dentro de una NavigationPage
            MainPage = new NavigationPage(new Views.WelcomePage());
        }
    }
}

