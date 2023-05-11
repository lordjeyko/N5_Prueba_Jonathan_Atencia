using Entidades_Dto.Negocio;
using Entidades_Dto.Perfiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N5_Data.Repositorio.Interfaz;

namespace N5_Api.Controllers
{
    /// <summary>
    /// Adminitracion de los perfiles, esto incluye los permisos y tipo de permisos
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public class PerfilesController : ControllerBase
    {
        private readonly IPerfilNegocio _Perfiles;
        public PerfilesController(IPerfilNegocio perfil)
        {
            _Perfiles = perfil;
        }

        /// <summary>
        /// Obtiene el listado completo de roles registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarRoles")]
        public async Task<ActionResult<BaseRespuesta<List<RolDto_Get>>>> Listar()
        {
            var resultado = await _Perfiles.ListaRoles();
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Obtiene el listado completo de tipos de rol registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarTiposDeRol")]
        public async Task<ActionResult<BaseRespuesta<List<TipoRolDto_Get>>>> ListarTipoRol()
        {
            var resultado = await _Perfiles.ListaTipoRol();
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Obtiene un rol, a traves de su identificador
        /// </summary>
        /// <param name="id">Identificador unico del rol</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerRol/{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<RolDto_Get>>> Obtener(Guid id)
        {
            var resultado = await _Perfiles.ObtenerRol(id);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Obtiene un tipo de rol, a traves de su identificador
        /// </summary>
        /// <param name="id">Identificador unico del tipo de rol</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerTiposDeRol/{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<TipoRolDto_Get>>> ObtenerTipoRol(Guid id)
        {
            var resultado = await _Perfiles.ObtenerTipoRol(id);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Genera un nuevo registro de un rol
        /// </summary>
        /// <param name="registro">Información del rol</param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegistrarRol")]
        public async Task<ActionResult<BaseRespuesta<RolDto_Get>>> Registrar(RolDto_Create registro)
        {
            var resultado = await _Perfiles.CrearRol(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Genera un nuevo registro de un tipo de rol
        /// </summary>
        /// <param name="registro">Información del tipo de rol</param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegistrarTiposDeRol")]
        public async Task<ActionResult<BaseRespuesta<TipoRolDto_Get>>> RegistrarTipoRol(TipoRolDto_Create registro)
        {
            var resultado = await _Perfiles.CrearTipoRol(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Permite la edicion de la informacion de un rol
        /// </summary>
        /// <param name="registro">Datos nuevos del rol y su identificador</param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarRol")]
        public async Task<ActionResult<BaseRespuesta<RolDto_Get>>> Modificar(RolDto_Get registro)
        {
            var resultado = await _Perfiles.ModificarRol(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Permite la edicion de la informacion de un tipo de rol
        /// </summary>
        /// <param name="registro">Datos nuevos del tipo de rol y su identificador</param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarTipoRol")]
        public async Task<ActionResult<BaseRespuesta<TipoRolDto_Get>>> ModificarTipoRol(TipoRolDto_Get registro)
        {
            var resultado = await _Perfiles.ModificarTipoRol(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Eliminación de rol especifico
        /// </summary>
        /// <param name="id">Identificador unico del rol</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("BorrarRol/{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<RolDto_Get>>> Borrar(Guid id)
        {
            RolDto_Get registro = new RolDto_Get() { Id = id};
            var resultado = await _Perfiles.EliminarRol(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Eliminación de un tipo de rol especifico
        /// </summary>
        /// <param name="id">Identificador unico del tipo de rol</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("BorrarTipoRol/{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<TipoRolDto_Get>>> BorrarTipoRol(Guid id)
        {
            var registro = new TipoRolDto_Get() { Id = id };
            var resultado = await _Perfiles.EliminarTipoRol(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Eliminación una congiracion de rol en usuario
        /// </summary>
        /// <param name="id">Identificador unico del tipo de perfil</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("BorrarPerfilUsuario/{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<PerfilDto_Get>>> BorrarPerfilUsuario(Guid id)
        {
            var registro = new PerfilDto_Get() { Id = id };
            var resultado = await _Perfiles.EliminarPerfil(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Modifica una congiracion de rol en usuario
        /// </summary>
        /// <param name="registro">Registro de perfil</param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarPerfilUsuario/{id:guid}")]
        public async Task<ActionResult<BaseRespuesta<PerfilDto_Get>>> ModificarPerfilUsuario(PerfilDto_Get registro)
        {
            var resultado = await _Perfiles.ModificarPerfil(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }

        /// <summary>
        /// Agregar una congiracion de rol en usuario
        /// </summary>
        /// <param name="registro">Registro de perfil</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarPerfilUsuario")]
        public async Task<ActionResult<BaseRespuesta<PerfilDto_Get>>> AgregarPerfilUsuario(PerfilDto_Create registro)
        {
            var resultado = await _Perfiles.CrearPerfil(registro);
            return StatusCode((int)resultado.Codigo, resultado);
        }
    }
}
