using AppProyectoInvest_MAUI.Controllers;
using AppProyectoInvest_MAUI.Models;

namespace AppProyectoInvest_MAUI.Views;

public partial class UsuarioInfoView : ContentPage
{
    private readonly ApiController apiController;

    public UsuarioInfoView()
    {
        InitializeComponent();
        apiController = new ApiController();
    }

    private async void OnObtenerInformacionClicked(object sender, EventArgs e)
{
    string cedula = CedulaEntry.Text;

    if (string.IsNullOrEmpty(cedula))
    {
        await DisplayAlert("Error", "Por favor, introduce tu c�dula.", "OK");
        return;
    }

    try
    {
        UsuarioResponse persona = await apiController.ObtenerNombrePorCedulaAsync(cedula);

        if (persona == null || persona.Results == null || persona.Results.Count == 0)
        {
            await DisplayAlert("Error", "No se encontraron datos para esta c�dula.", "OK");
            return;
        }

        var resultado = persona.Results[0];

        NombreLabel.Text = $"Nombre Completo: {resultado.Fullname}";
        CedulaLabel.Text = $"C�dula: {resultado.Cedula}";
        TipoIdentificacionLabel.Text = $"Tipo Identificaci�n: {resultado.GuessType}";
        LicenseLabel.Text = $"Licencia: {persona.License}";
    }
    catch (Exception ex)
    {
        await DisplayAlert("Error", $"No se pudo obtener la informaci�n: {ex.Message}", "OK");
    }
}
}