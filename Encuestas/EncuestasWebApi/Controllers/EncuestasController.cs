using Encuestas.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncuestasWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
        static List<Encuesta> lista;
        private readonly ILogger<EncuestaController> _logger;

        public EncuestaController(ILogger<EncuestaController> logger)
        {
            _logger = logger;

            if (lista==null)
            {
                lista=new List<Encuesta> { new Encuesta() { Nombre = "Fernando" } };
            }
        }

        [HttpGet]
        public IEnumerable<Encuesta> Get()
        {
            return EncuestaController.lista;
        }

        [HttpGet("{id:int}", Name = "GetEncuestaById")]
        public Encuesta Get(int id)
        {
            return EncuestaController.lista[0];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Encuesta nueva)
        {
            lista.Add(nueva);
        }

    }
}
