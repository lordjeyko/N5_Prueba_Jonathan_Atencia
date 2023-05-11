using Entidades_Dto.Perfiles;

namespace Entidades_Dto.Empleado
{
    public class EmpleadoDto_Get
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }

        public List<RolDto_Get> Perfiles { get; set; }
    }
}
