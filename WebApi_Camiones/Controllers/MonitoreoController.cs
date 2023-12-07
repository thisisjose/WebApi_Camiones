using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoreoController : ControllerBase
    {
        private readonly MonitoreoService _monitoreoService;

        public MonitoreoController(MonitoreoService monitoreoService)
        {
            _monitoreoService = monitoreoService;
        }

        [HttpGet("Listar_hora")]
        public IActionResult GetAllRutas()
        {
            var rutas = _monitoreoService.GetAllRutas();
            return Ok(rutas);
        }

        [HttpGet("Obtener_hora_por_id/{id}")]
        public IActionResult GetRutasById(int id)
        {
            var ruta = _monitoreoService.GetRutaById(id);
            return Ok(ruta);
        }

        [HttpPost("Agregar-hora")]
        public IActionResult AgregarRuta([FromBody] RutaVM ruta)
        {
            _monitoreoService.AgregarRuta(ruta);
            return Ok();
        }

        [HttpPut("actualizar_horas_por_id/{id}")]
        public IActionResult EditarRuta(int id, [FromBody] RutaVM ruta)
        {
            var rutaEditada = _monitoreoService.EditarRuta(id, ruta);

            if (rutaEditada == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("Eliminar-hora-por-Id/{id}")]
        public IActionResult EliminarRuta(int id)
        {
            _monitoreoService.EliminarRuta(id);
            return Ok();
        }

        [HttpGet("Obtener_hora-con-camiones_por_id/{id}")]
        public IActionResult GetRutaWithCamiones(int id)
        {
            var ruta = _monitoreoService.GetRutaWithCamiones(id);

            if (ruta == null)
            {
                return NotFound();
            }

            return Ok(ruta);
        }
    }
}