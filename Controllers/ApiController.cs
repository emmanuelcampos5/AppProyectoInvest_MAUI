using AppProyectoInvest_MAUI.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppProyectoInvest_MAUI.Controllers
{
    public class ApiController
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };
        private const string BaseUrl = "https://apis.gometa.org/cedulas/";

        public ApiController(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<UsuarioResponse> ObtenerNombrePorCedulaAsync(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                throw new ArgumentException("La cédula no puede ser nula o vacía.", nameof(cedula));

            string url = $"{BaseUrl}{cedula}";

            try
            {
                return await RealizarSolicitudHttpAsync(url);
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is JsonException)
            {
                throw new Exception("Error al obtener o procesar la información del API.", ex);
            }
        }

        private async Task<UsuarioResponse> RealizarSolicitudHttpAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<UsuarioResponse>(jsonResponse, _jsonOptions)
                   ?? throw new JsonException("La respuesta del API es nula o está malformada.");
        }
    }
}
