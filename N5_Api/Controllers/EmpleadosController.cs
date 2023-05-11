using Entidades_Dto.Empleado;
using Entidades_Dto.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N5_Data.Repositorio.Interfaz;

namespace N5_Api.Controllers
{
    /// <summary>
    /// Administrador de Empleados
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoNegocio _Empleado;
        public EmpleadosController(IEmpleadoNegocio empleado)
        {
            _Empleado = empleado;
        }

        /// <summary>
        /// Permite listar todos los empleados, esto con el fin de validar 
        /// la data para pruebas
        /// </summary>
        /// <returns>Listado de empleados</returns>
        [HttpGet]
        public async Task<ActionResult<BaseRespuesta<List<EmpleadoDto_Get>>>> Listar()
        {
            var resultado = await _Empleado.ListaEmpleados();
            return StatusCode((int)resultado.Codigo, resultado);
        }

        [HttpGet]
        [Route("{id:guid}")]
        
        
        public async Task<ActionResult<BaseRespuesta<EmpleadoDto_Get>>> Obtener(Guid id)
        {
            var resultado = await _Empleado.ObtenerEmpleado(id);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        [HttpPost]
        public async Task<ActionResult<BaseRespuesta<EmpleadoDto_Get>>> Registrar(EmpleadoDto_Create registro)
        {
            var resultado = await _Empleado.CrearEmpleado(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        [HttpPut]
        public async Task<ActionResult<BaseRespuesta<EmpleadoDto_Get>>> Modificar(EmpleadoDto_Get registro)
        {
            var resultado = await _Empleado.ModificarEmpleado(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<EmpleadoDto_Get>>> Borrar(Guid id)
        {
            EmpleadoDto_Get registro = new EmpleadoDto_Get() { Id = id};
            var resultado = await _Empleado.EliminarEmpleado(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }
    }
}
