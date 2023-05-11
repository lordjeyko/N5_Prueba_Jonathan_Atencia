using Entidades_Dto.Perfiles;
using N5_Data.Entidades.Perfiles;
using N5_Data.Negocio.Interfaz;

namespace N5_Data.Repositorio.Interfaz
{
    public interface ITipoRolRepositorio : IBaseRepositorio<TipoRol>
    {
        Task<List<TipoRolDto_Get>> TipoRol_Obtener_Todo();
        Task<TipoRolDto_Get> TipoRol_Obtener_Id(Guid guid);
        Task<TipoRolDto_Get> TipoRol_Crear(TipoRolDto_Create elemento);
        Task<TipoRolDto_Get> TipoRol_Modificar(TipoRolDto_Get elemento);
        Task<TipoRolDto_Get> TipoRol_Eliminar(TipoRolDto_Get elemento);
    }
}
