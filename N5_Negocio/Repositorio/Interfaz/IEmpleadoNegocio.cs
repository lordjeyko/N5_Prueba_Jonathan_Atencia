using Entidades_Dto.Empleado;
using Entidades_Dto.Negocio;

namespace N5_Data.Repositorio.Interfaz
{
    public interface IEmpleadoNegocio 
    {
        Task<BaseRespuesta<List<EmpleadoDto_Get>>> ListaEmpleados();
        Task<BaseRespuesta<EmpleadoDto_Get>> ObtenerEmpleado(Guid guid);
        Task<BaseRespuesta<EmpleadoDto_Get>> CrearEmpleado(EmpleadoDto_Create elemento);
        Task<BaseRespuesta<EmpleadoDto_Get>> ModificarEmpleado(EmpleadoDto_Get elemento);
        Task<BaseRespuesta<EmpleadoDto_Get>> EliminarEmpleado(EmpleadoDto_Get elemento);
    }
}
