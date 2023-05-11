using AutoMapper;
using N5_Data.Negocio.Interfaz;
using N5_Data.Repositorio.Implementacion;
using N5_Data.Repositorio.Interfaz;

namespace N5_Data.Negocio.Implementacion
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        protected readonly DB_Contexto _Contexto;
        protected readonly IMapper _Mapeo;
        public UnidadDeTrabajo(DB_Contexto contexto, IMapper mapeo)
        {
            _Contexto = contexto;
            _Mapeo = mapeo;
        }
        public IEmpleadoRepositorio Empleado => new EmpleadoRepositorio(_Contexto, _Mapeo);
        public IRolRepositorio Rol => new RolRepositorio(_Contexto, _Mapeo);
        public ITipoRolRepositorio TipoRol => new TipoRolRepositorio(_Contexto, _Mapeo);
        public IPerfiRepositorio Perfil => new PerfiRepositorio(_Contexto, _Mapeo);
    }
}
