using Entidades_Dto.Perfiles;
using N5_Data.Entidades.Perfiles;
using N5_Data.Negocio.Interfaz;

namespace N5_Data.Repositorio.Interfaz
{
    public interface IRolRepositorio : IBaseRepositorio<Rol>
    {
        Task<List<RolDto_Get>> Rol_Obtener_Todo();
        Task<RolDto_Get> Rol_Obtener_Id(Guid guid);
        Task<RolDto_Get> Rol_Crear(RolDto_Create elemento);
        Task<RolDto_Get> Rol_Modificar(RolDto_Get elemento);
        Task<RolDto_Get> Rol_Eliminar(RolDto_Get elemento);
    }
}
