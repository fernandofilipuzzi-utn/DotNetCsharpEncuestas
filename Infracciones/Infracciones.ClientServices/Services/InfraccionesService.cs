using Infracciones.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Infracciones.ClientServices.Services
{
    public class InfraccionesService
    {
        public async Task<Infraccion> Prueba()
        {
            string baseUrl = "https://infracciones.somee.com/api/Infraccion/1";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        string dataJson = await response.Content.ReadAsStringAsync();

                        var infraccion = JsonConvert.DeserializeObject<Infraccion>(dataJson);

                        return infraccion;
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
