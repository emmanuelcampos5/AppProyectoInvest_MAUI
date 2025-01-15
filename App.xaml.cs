namespace AppProyectoInvest_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.UsuarioInfoView();
        }
    }
}
