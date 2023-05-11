namespace N5_Data.Negocio.Implementacion
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using N5_Data.Negocio.Interfaz;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class BaseRepositorio<TEntidad> : IBaseRepositorio<TEntidad> where TEntidad : class
    {
        protected readonly DB_Contexto _Contexto;
        protected readonly IMapper _Mapeo;
        private DbSet<TEntidad> _DbSetEntidad;

        public BaseRepositorio(DB_Contexto contexto, IMapper mapeo)
        {
            _Contexto = contexto;
            _Mapeo = mapeo;
            _DbSetEntidad = _Contexto.Set<TEntidad>();
        }

        public DbSet<TEntidad> DbSetEntidad
        {
            get
            {
                _DbSetEntidad = _DbSetEntidad ?? _Contexto.Set<TEntidad>();
                return _DbSetEntidad;
            }
        }

        public async Task<int> Cantidad(Expression<Func<TEntidad, bool>> filtro)
        {
            return await DbSetEntidad.AsNoTracking().CountAsync(filtro);
        }

        public async Task<TEntidad> Crear(TEntidad entidad, bool GuardarCambios = false)
        {
            var _entidad = DbSetEntidad.Add(entidad);
            if (GuardarCambios)
                await _Contexto.SaveChangesAsync();
            return _entidad.Entity;
        }

        public async Task<TEntidad> Eliminar(TEntidad entidad, bool GuardarCambios = false)
        {
            var _entidad = _Contexto.Entry(entidad);
            DbSetEntidad.Remove(entidad);
            _entidad.State = EntityState.Deleted;
            if (GuardarCambios)
                await _Contexto.SaveChangesAsync();
            return _entidad.Entity;
        }

        public async Task Eliminar(Expression<Func<TEntidad, bool>> filtro, bool GuardarCambios = false)
        {
            var listado = DbSetEntidad.Where(filtro).ToList();
            DbSetEntidad.RemoveRange(listado);
            if (GuardarCambios)
                await _Contexto.SaveChangesAsync();
        }

        public async Task<bool> Existe(Expression<Func<TEntidad, bool>> filtro)
        {
            return await DbSetEntidad.AsNoTracking().AnyAsync(filtro);
        }



        public async Task<TEntidad> Modificar(TEntidad entidad, bool GuardarCambios = false)
        {
            var _entidad = _Contexto.Entry(entidad);
            DbSetEntidad.Attach(entidad);
            _entidad.State = EntityState.Modified;
            if (GuardarCambios)
                await _Contexto.SaveChangesAsync();
            return _entidad.Entity;
        }

        public async Task<TEntidad> ObtenerEntidad(Expression<Func<TEntidad, bool>> filtro)
        {
            return await DbSetEntidad.AsNoTracking().FirstOrDefaultAsync(filtro);
        }

        public async Task<IList<TEntidad>> ObtenerFiltro(Expression<Func<TEntidad, bool>> filtro)
        {
            var resultado = await DbSetEntidad.AsNoTracking().Where(filtro).ToListAsync();
            return resultado;
        }

        public async Task<IList<TEntidad>> ObtenerTodo()
        {
            var resultado = await DbSetEntidad.AsNoTracking().ToListAsync();
            return resultado;
        }
    }
}
