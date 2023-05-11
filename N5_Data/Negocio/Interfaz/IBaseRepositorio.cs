namespace N5_Data.Negocio.Interfaz
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public interface IBaseRepositorio<TEntidad> where TEntidad : class
    {
        #region Metodos Sincronicos
        DbSet<TEntidad> DbSetEntidad { get; }

        Task<IList<TEntidad>> ObtenerTodo();
        Task<IList<TEntidad>> ObtenerFiltro(Expression<Func<TEntidad, bool>> filtro);
        Task<TEntidad> ObtenerEntidad(Expression<Func<TEntidad, bool>> filtro);

        Task<TEntidad> Crear(TEntidad entidad, bool GuardarCambios = false);
        Task<TEntidad> Modificar(TEntidad entidad, bool GuardarCambios = false);
        Task<TEntidad> Eliminar(TEntidad entidad, bool GuardarCambios = false);
        Task Eliminar(Expression<Func<TEntidad, bool>> filtro, bool GuardarCambios = false);
        Task<int> Cantidad(Expression<Func<TEntidad, bool>> filtro);
        Task<bool> Existe(Expression<Func<TEntidad, bool>> filtro);
        #endregion

        #region Metodos Asincronicos
        #endregion
    }
}
