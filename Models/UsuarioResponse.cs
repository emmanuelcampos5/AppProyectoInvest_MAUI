using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppProyectoInvest_MAUI.Models
{
    public class UsuarioResponse
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("database_date")]
        public string DatabaseDate { get; set; }

        [JsonPropertyName("tipoIdentificacion")]
        public string TipoIdentificacion { get; set; }

        [JsonPropertyName("cedula")]
        public string Cedula { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; }

        [JsonPropertyName("results")]
        public List<UsuarioResult> Results { get; set; }
    }

    public class UsuarioResult
    {
        [JsonPropertyName("fullname")]
        public string Fullname { get; set; }

        [JsonPropertyName("guess_type")]
        public string GuessType { get; set; }

        [JsonPropertyName("cedula")]
        public string Cedula { get; set; }
    }
}

