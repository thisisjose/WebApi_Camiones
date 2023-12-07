using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionesController : ControllerBase
    {
        public CamionesServices _camionesService;

        public CamionesController(CamionesServices camionesService)
        {
            _camionesService = camionesService;
        }

        [HttpGet("Listar_camiones")]
        public IActionResult GetAllCamiones()
        {
            var allCamiones = _camionesService.GetAllCamiones();
            return Ok(allCamiones);
        }

        [HttpGet("Obtener_camiones_por_id/{id}")]
        public IActionResult GetCamionesById(int id)
        {
            var camiones = _camionesService.GetCamionesByID(id);
            return Ok(camiones);
        }
      
        [HttpPost("Agregar-Camiones")]
        public IActionResult AgregarCamionero([FromBody] CamionesVM camiones)
        {
            _camionesService.AgregarCamiones(camiones);
            return Ok();
        }
        
        [HttpPut("Actualizar_camiones_por_id/{id}")]
        public IActionResult EditarCamion(int id, [FromBody] CamionesVM camiones)
        {
            _camionesService.EditarCamiones(id, camiones);
            return Ok();
        }

        [HttpDelete("Eliminar-camiones-por-Id/{id}")]
        public IActionResult EliminarCamiones(int id)
        {
            _camionesService.EliminarPorID(id);
            return Ok();
        }

    }
}
