# Aplicación .NET8 (en construcción)

- Aplicación MAUI
- WebAPI

## Solución

<div align="center">
        <img style="width:50%;" src="Infracciones/solucion.jpg"/>
        <p>Figura 1. Solución /p>
</div>


## Aplicación móvil

Immplementación del botón
```csharp
        private async void btnPrueba_Clicked(System.Object sender, System.EventArgs e)
        {
            InfraccionesService servicio = new InfraccionesService();
            var infraccion = await servicio.Prueba();
            if (infraccion != null)
            {
                lbnRespuesta.Text = infraccion.Nombre;
            }
            else
            {
                lbnRespuesta.Text = "-";
            }
        }
```

## Proyecto - librería de clases- llamada a la API

La llamada de prueba a la API
```csharp
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
```

## WebAPI
<a href="https://infracciones.somee.com/swagger/index.html">swagger</a> 
