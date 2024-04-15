using Infracciones.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfraccionController : ControllerBase
    {
        static List<Infraccion> lista;
        private readonly ILogger<InfraccionController> _logger;

        public InfraccionController(ILogger<InfraccionController> logger)
        {
            _logger = logger;

            if (lista==null)
            {
                lista=new List<Infraccion> { new Infraccion() { Nombre = "Fernando" } };
            }
        }

        [HttpGet]
        public IEnumerable<Infraccion> Get()
        {
            return InfraccionController.lista;
        }

        [HttpGet("{id:int}", Name = "GetInfraccionById")]
        public Infraccion Get(int id)
        {
            return InfraccionController.lista[0];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Infraccion nueva)
        {
            lista.Add(nueva);
        }

    }
}
