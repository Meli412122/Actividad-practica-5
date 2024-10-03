using ActividadPractica5.Modelos;
using ActividadPractica5.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadPractica5.Controlador
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosControlador : ControllerBase
    {
        private ITurnosRepositorio _repositorio;
        public TurnosControlador(ITurnosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        // GET: api/<TurnosControlador>
        [HttpGet]
        public IActionResult Get(int id =-1, string fecha = "", string hora = "", string cliente = "")
        {
            try
            {
                return Ok(_repositorio.GetALL( id,  fecha,  hora,  cliente));
            }
            catch (Exception )
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            try
            {
                if (validar(turno))
                {
                    return Ok(_repositorio.Crear(turno));
                }
                else
                    return BadRequest("Completar los campos");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        private bool validar(TTurno turno)
        {
            return !string.IsNullOrEmpty(turno.Cliente)
                && !string.IsNullOrEmpty(turno.Fecha)
                && !string.IsNullOrEmpty(turno.Hora);


        }

        // PUT api/<TurnosControlador>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]TTurno turnoActualizado)
        {
            try
            {
                return Ok(_repositorio.Actualizar(id, turnoActualizado));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }

        }

        [HttpPut("DarBaja/{id}")]
        public IActionResult Put2(int id)
        {
            try
            {
                if (_repositorio.BajaTurnos(id))
                    return Ok("Cliente dado de baja");
                else
                    return NotFound("No se encontro el id");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }

        }

    }
}
