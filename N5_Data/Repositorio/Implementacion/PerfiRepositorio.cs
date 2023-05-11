using AutoMapper;
using Entidades_Dto.Perfiles;
using Microsoft.EntityFrameworkCore;
using N5_Data.Entidades.Perfiles;
using N5_Data.Negocio.Implementacion;
using N5_Data.Repositorio.Interfaz;

namespace N5_Data.Repositorio.Implementacion
{
    public class PerfiRepositorio : BaseRepositorio<PerfilUsuario>, IPerfiRepositorio
    {
        public PerfiRepositorio(DB_Contexto contexto, IMapper mapeo) : base(contexto, mapeo)
        {
        }

        public async Task<PerfilDto_Get> Perfil_Crear(PerfilDto_Create elemento)
        {
            var registro = _Mapeo.Map<PerfilUsuario>(elemento);
            registro.uRolId = await _Contexto.Roles.FirstOrDefaultAsync(y => y.uId == elemento.RolId);
            registro.uUsuarioId = await _Contexto.Empleados.FirstOrDefaultAsync(y => y.uId == elemento.UsuarioId);
            var resultado = await Crear(registro, true);
            return _Mapeo.Map<PerfilDto_Get>(resultado);
        }

        public async Task<PerfilDto_Get> Perfil_Eliminar(PerfilDto_Get elemento)
        {
            var registro = _Mapeo.Map<PerfilUsuario>(elemento);
            var resultado = await Eliminar(registro, true);
            return _Mapeo.Map<PerfilDto_Get>(resultado);
        }

        public async Task<PerfilDto_Get> Perfil_Modificar(PerfilDto_Get elemento)
        {
            var registro = _Mapeo.Map<PerfilUsuario>(elemento);
            registro.uRolId = await _Contexto.Roles.FirstOrDefaultAsync(y => y.uId == elemento.RolId);
            registro.uUsuarioId = await _Contexto.Empleados.FirstOrDefaultAsync(y => y.uId == elemento.UsuarioId);
            var resultado = await Modificar(registro, true);
            return _Mapeo.Map<PerfilDto_Get>(resultado);
        }
    }
}
