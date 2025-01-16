using AppProyectoInvest_MAUI.Controllers;
using AppProyectoInvest_MAUI.Models;

namespace AppProyectoInvest_MAUI.Views;

public partial class UsuarioInfoView : ContentPage
{
    private readonly ApiController apiController;

    public UsuarioInfoView()
    {
        InitializeComponent();
        var httpClient = new HttpClient();
        apiController = new ApiController(httpClient);
    }

    private async void OnObtenerInformacionClicked(object sender, EventArgs e)
    {
        string cedula = CedulaEntry.Text;

        if (string.IsNullOrEmpty(cedula))
        {
            await DisplayAlert("Error", "Por favor, introduce tu cédula.", "OK");
            return;
        }

        try
        {
            UsuarioResponse persona = await apiController.ObtenerNombrePorCedulaAsync(cedula);

            if (persona == null || persona.Results == null || persona.Results.Count == 0)
            {
                await DisplayAlert("Error", "No se encontraron datos para esta cédula.", "OK");
                return;
            }

            var resultado = persona.Results[0];

            NombreLabel.Text = $"Nombre Completo: {resultado.Fullname}";
            CedulaLabel.Text = $"Cédula: {resultado.Cedula}";
            TipoIdentificacionLabel.Text = $"Tipo Identificación: {resultado.GuessType}";
        
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo obtener la información: {ex.Message}", "OK");
        }
    }
    private void OnLimpiarClicked(object sender, EventArgs e)
    {
        
        CedulaEntry.Text = string.Empty;
        NombreLabel.Text = "";
        CedulaLabel.Text = "";
        TipoIdentificacionLabel.Text = "";
    }
}