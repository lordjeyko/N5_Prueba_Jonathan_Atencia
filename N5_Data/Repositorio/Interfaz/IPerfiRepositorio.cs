using Entidades_Dto.Perfiles;
using N5_Data.Entidades.Perfiles;
using N5_Data.Negocio.Interfaz;

namespace N5_Data.Repositorio.Interfaz
{
    public interface IPerfiRepositorio : IBaseRepositorio<PerfilUsuario>
    {
        Task<PerfilDto_Get> Perfil_Crear(PerfilDto_Create elemento);
        Task<PerfilDto_Get> Perfil_Modificar(PerfilDto_Get elemento);
        Task<PerfilDto_Get> Perfil_Eliminar(PerfilDto_Get elemento);
    }
}
