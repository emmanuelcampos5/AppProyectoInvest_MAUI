using AppProyectoInvest_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppProyectoInvest_MAUI.Controllers
{
    public class ApiController
    {
        private readonly HttpClient _httpClient;

        public ApiController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<UsuarioResponse> ObtenerNombrePorCedulaAsync(string cedula)
        {
            string url = $"https://apis.gometa.org/cedulas/{cedula}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener datos: {response.StatusCode}");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserializa la respuesta JSON
            var resultado = JsonSerializer.Deserialize<UsuarioResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return resultado;
        }
    }
}
