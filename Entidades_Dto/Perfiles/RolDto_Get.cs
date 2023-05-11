using Entidades_Dto.Empleado;

namespace Entidades_Dto.Perfiles
{
    public class RolDto_Get
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public List<TipoRolDto_Get> TiposRol { get; set; }
        public List<EmpleadoDto_Get> Usuarios { get; set; }
    }
}
