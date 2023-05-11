using AutoMapper;
using Entidades_Dto.Perfiles;
using Microsoft.EntityFrameworkCore;
using N5_Data.Entidades.Perfiles;
using N5_Data.Negocio.Implementacion;
using N5_Data.Repositorio.Interfaz;

namespace N5_Data.Repositorio.Implementacion
{
    public class TipoRolRepositorio : BaseRepositorio<TipoRol>, ITipoRolRepositorio
    {
        public TipoRolRepositorio(DB_Contexto contexto, IMapper mapeo) : base(contexto, mapeo)
        {
        }

        public async Task<TipoRolDto_Get> TipoRol_Crear(TipoRolDto_Create elemento)
        {
            TipoRol registro = _Mapeo.Map<TipoRol>(elemento);
            registro.Rol = await _Contexto.Roles.FirstOrDefaultAsync(y => y.uId == elemento.PermisoId);
            var resultado = await Crear(registro, true);
            return _Mapeo.Map<TipoRolDto_Get>(resultado);
        }

        public async Task<TipoRolDto_Get> TipoRol_Eliminar(TipoRolDto_Get elemento)
        {
            TipoRol registro = _Mapeo.Map<TipoRol>(elemento);
            var resultado = await Eliminar(registro, true);
            return _Mapeo.Map<TipoRolDto_Get>(resultado);
        }

        public async Task<TipoRolDto_Get> TipoRol_Modificar(TipoRolDto_Get elemento)
        {
            TipoRol registro = _Mapeo.Map<TipoRol>(elemento);
            registro.Rol = await _Contexto.Roles.FirstOrDefaultAsync(y => y.uId == elemento.PermisoId);
            var resultado = await Modificar(registro, true);
            return _Mapeo.Map<TipoRolDto_Get>(resultado);
        }

        public async Task<TipoRolDto_Get> TipoRol_Obtener_Id(Guid guid)
        {
            var resultado = await ObtenerEntidad(r => r.uId == guid);
            return _Mapeo.Map<TipoRolDto_Get>(resultado);
        }

        public async Task<List<TipoRolDto_Get>> TipoRol_Obtener_Todo()
        {
            var resultado = await ObtenerTodo();
            return _Mapeo.Map<List<TipoRolDto_Get>>(resultado);
        }
    }
}
