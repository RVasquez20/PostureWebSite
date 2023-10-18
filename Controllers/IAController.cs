using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PostureWebSite.Models;
using PostureWebSite.Models.Request;
using PostureWebSite.Models.Response;
using PostureWebSite.Repository;

namespace PostureWebSite.Controllers
{
    public class IAController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IRepositoryAsync<RegistroBotone> _botoneRepository;
        public IAController(IHttpClientFactory httpClientFactory, 
            IConfiguration configuration,
            IRepositoryAsync<RegistroBotone> botoneRepository)
        {
            this._httpClientFactory = httpClientFactory;
            this._configuration = configuration;
            this._botoneRepository = botoneRepository;
        }
        public async Task<IActionResult> Analisis()
        {
            
            return View();
        }

        public async Task<IActionResult> DataAnalisis()
        {
            var data = await _botoneRepository.GetAll();
            StringBuilder result = new StringBuilder("IdRegistroBotones\tFechaHora\tDuracion\tBoton1\tBoton2\tBoton3\tBoton4\tBoton5\tBoton6\tIdUser\n");

            foreach (var record in data)
            {
                string formattedDate = record.FechaHora?.ToString("yyyy-MM-dd HH:mm:ss.fff") ?? "N/A";
                int boton1 = record.Boton1.HasValue && record.Boton1.Value ? 1 : 0;
                int boton2 = record.Boton2.HasValue && record.Boton2.Value ? 1 : 0;
                int boton3 = record.Boton3.HasValue && record.Boton3.Value ? 1 : 0;
                int boton4 = record.Boton4.HasValue && record.Boton4.Value ? 1 : 0;
                int boton5 = record.Boton5.HasValue && record.Boton5.Value ? 1 : 0;
                int boton6 = record.Boton6.HasValue && record.Boton6.Value ? 1 : 0;

                result.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\n",
                    record.IdRegistroBotones,
                    formattedDate,
                    record.Duracion ?? 0,
                    boton1,
                    boton2,
                    boton3,
                    boton4,
                    boton5,
                    boton6,
                    record.IdUser ?? 1);
            }

            var query = string.Concat(result.ToString(), this._configuration["IA:Prompt"]);
            var mesage = new List<Messages>();
            mesage.Add(new Messages()
            {
                role = this._configuration["IA:Role"],
                content = query
            });
            var request = new IARequest
            {
                model = this._configuration["IA:Modelo"],
                messages = mesage
            };
            var client = _httpClientFactory.CreateClient("Base");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._configuration["IA:Token"]);
            var response = await client.PostAsJsonAsync("", request);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<IAResponse>();
                var dataSugerencias = JsonSerializer.Deserialize<DataSugerencias>(resultado.choices[0].message.content);
                return Json( new { success = true, data = dataSugerencias });
            }
            return Json(new { success = false });
        }

    }
}
