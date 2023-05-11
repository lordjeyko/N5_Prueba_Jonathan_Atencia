using N5_Data.Repositorio.Interfaz;

namespace N5_Data.Negocio.Interfaz
{
    public interface IUnidadDeTrabajo
    {
        #region Repositorio
        IEmpleadoRepositorio Empleado { get; }
        IRolRepositorio Rol { get; }
        ITipoRolRepositorio TipoRol { get; }
        IPerfiRepositorio Perfil { get; }
        #endregion
    }
}
