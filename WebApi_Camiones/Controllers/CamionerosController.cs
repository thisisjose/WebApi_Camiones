using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi_Camiones.Datos.Services;
using WebApi_Camiones.Datos.ViewModels;

namespace WebApi_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionerosController : ControllerBase
    {
        public CamionerosService _camionerosService;
        public CamionerosController(CamionerosService camionerosService)
        {
            
            _camionerosService = camionerosService;
        }

        [HttpGet("Listar_camioneros")]
        public IActionResult GetAllCamioneros()
        {
            var allCamioneros = _camionerosService.GetAllCamioneros();
            if(allCamioneros!=null)
            return Ok(allCamioneros);
            else
                throw new Exception($"No existen camioneros registrados");
        }

        [HttpGet("Obtener_camioneros_por_id/{id}")]
        public IActionResult GetCamionerosById(int id)
        {
            try { 
            var camionero = _camionerosService.GetCamionerosByID(id);
            return Ok(camionero);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Agregar-Camionero")]
        public IActionResult AgregarCamionero([FromBody]CamioneroVM camionero)
        {
            try
            {
                _camionerosService.AgregarCamionero(camionero);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("actualizar_camioneros_por_id/{id}")]
        public IActionResult EditarCamionero(int id, [FromBody] CamioneroVM camionero)
        {
            try { 
                _camionerosService.EditarCamionero(id,camionero);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
             }
        }

        [HttpDelete("Eliminar-camion-por-Id/{id}")]
        public IActionResult EliminarCamionero(int id)
        {
            try
            {
                _camionerosService.EliminarPorID(id);
                return Ok();
            }
            catch(Exception ex) { 
            
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Obtener_camioneros-con-camiones_por_id/{id}")]
        public IActionResult GetCamnioneroWithcamiones(int id)
        {
            try
            {
                var camionero = _camionerosService.GetCamioneroWithCamiones(id);
                return Ok(camionero);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
