using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        public RutaService _rutaService;
        public RutaController(RutaService rutaService)
        {
            _rutaService = rutaService;
        }

        [HttpGet("Listar_rutas")]
        public IActionResult GetAllRutas()
        {
            var allBooks = _rutaService.GetAllRutas();
            return Ok(allBooks);
        }

        [HttpGet("Obtener_rutas_por_id/{id}")]
        public IActionResult GetRutasById(int id)
        {

            var ruta = _rutaService.GetRutasById(id);
            return Ok(ruta);
        }

        [HttpPost("Agregar-Ruta")]
        public IActionResult AgregarRuta([FromBody] RutaVM ruta)
        {
            _rutaService.AgregarRuta(ruta);
            return Ok();
        }

        [HttpPut("actualizar_rutas_por_id/{id}")]
        public IActionResult EditarRuta(int id, [FromBody] RutaVM ruta)
        {
            _rutaService.EditarRuta(id, ruta);
            return Ok();
        }

        [HttpDelete("Eliminar-ruta-por-Id/{id}")]
        public IActionResult EliminarRuta(int id)
        {
            _rutaService.EliminarPorID(id);
            return Ok();
        }

        [HttpGet("Obtener_ruta-con-camiones_por_id/{id}")]
        public IActionResult GetRutaWithCamiones(int id)
        {

            var ruta = _rutaService.GetRutaWithCamiones(id);
            return Ok(ruta);
        }
    }
}
