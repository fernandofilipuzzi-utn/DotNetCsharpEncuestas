using Encuestas.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Encuestas.ClientServices.Services
{
    public class EncuestasService
    {
        public async Task<Encuesta> Prueba()
        {
            string baseUrl = "https://encuesta.somee.com/api/Encuesta/1";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        string dataJson = await response.Content.ReadAsStringAsync();

                        var encuesta = JsonConvert.DeserializeObject<Encuesta>(dataJson);

                        return encuesta;
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
            return null;
        }

    }
}
