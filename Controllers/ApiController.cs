using AppProyectoInvest_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppProyectoInvest_MAUI.Controllers
{
    public static class ApiController
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://www.tallerweb.somee.com/api")
        };

        //public static async Task<ApiResponse> Login(UserLogin userLogin)
        //{
        //    try
        //    {
        //        var json = JsonSerializer.Serialize(userLogin);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _httpClient.PostAsync("/Usuario", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseBody = await response.Content.ReadAsStringAsync();
        //            return JsonSerializer.Deserialize<ApiResponse>(responseBody);
        //        }

        //        return new ApiResponse
        //        {
        //            Success = false,
        //            Message = "Error al iniciar sesión. Inténtelo nuevamente."
        //        };
        //    }
        //    catch(Exception ex)
        //    {
        //        return new ApiResponse
        //        {
        //            Success = false,
        //            Message = "Error de conexión. Por favor, revise su conexión a Internet."
        //        };
        //    }
        //}

        public static async Task<ApiResponse> Login(UserLogin userLogin)
        {
                return new ApiResponse
                {
                    Success = true,
                    Message = "Sesion iniciada correctamente, Bienvenido " + userLogin.Email
                };                      
        }
    }
}
