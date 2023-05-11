using AutoMapper;
using Entidades_Dto.Perfiles;
using Microsoft.EntityFrameworkCore;
using N5_Data.Entidades.Perfiles;
using N5_Data.Negocio.Implementacion;
using N5_Data.Repositorio.Interfaz;

namespace N5_Data.Repositorio.Implementacion
{
    public class RolRepositorio : BaseRepositorio<Rol>, IRolRepositorio
    {
        public RolRepositorio(DB_Contexto contexto, IMapper mapeo) : base(contexto, mapeo)
        {
        }

        public async Task<RolDto_Get> Rol_Crear(RolDto_Create elemento)
        {
            Rol registro = _Mapeo.Map<Rol>(elemento);
            var resultado = await Crear(registro, true);
            return _Mapeo.Map<RolDto_Get>(resultado);
        }

        public async Task<RolDto_Get> Rol_Eliminar(RolDto_Get elemento)
        {
            Rol registro = _Mapeo.Map<Rol>(elemento);
            var resultado = await Eliminar(registro, true);
            return _Mapeo.Map<RolDto_Get>(resultado);
        }

        public async Task<RolDto_Get> Rol_Modificar(RolDto_Get elemento)
        {
            Rol registro = _Mapeo.Map<Rol>(elemento);
            var resultado = await Modificar(registro, true);
            return _Mapeo.Map<RolDto_Get>(resultado);
        }

        public async Task<RolDto_Get> Rol_Obtener_Id(Guid guid)
        {
            var resultado = await DbSetEntidad.AsNoTracking()
                                    .Include(x => x.TiposRol)
                                    .Include(x => x.Usuarios)
                                    .FirstOrDefaultAsync(r => r.uId == guid);
            return _Mapeo.Map<RolDto_Get>(resultado);
        }

        public async Task<List<RolDto_Get>> Rol_Obtener_Todo()
        {
            var resultado = await DbSetEntidad.AsNoTracking()
                                    .Include(x => x.TiposRol)
                                    .Include(x => x.Usuarios)
                                    .ToListAsync();
            return _Mapeo.Map<List<RolDto_Get>>(resultado);
        }
    }
}
