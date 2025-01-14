using AppProyectoInvest_MAUI.ViewModels;

namespace AppProyectoInvest_MAUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}