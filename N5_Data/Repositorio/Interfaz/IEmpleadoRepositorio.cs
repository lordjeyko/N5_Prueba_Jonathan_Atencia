namespace N5_Data.Repositorio.Interfaz
{
    using Entidades_Dto.Empleado;
    using N5_Data.Entidades.Empleados;
    using N5_Data.Negocio.Interfaz;

    public interface IEmpleadoRepositorio : IBaseRepositorio<Empleado>
    {
        Task<List<EmpleadoDto_Get>> Empleado_Obtener_Todo();
        Task<EmpleadoDto_Get> Empleado_Obtener_Id(Guid guid);
        Task<EmpleadoDto_Get> Empleado_Crear(EmpleadoDto_Create elemento);
        Task<EmpleadoDto_Get> Empleado_Modificar(EmpleadoDto_Get elemento);
        Task<EmpleadoDto_Get> Empleado_Eliminar(EmpleadoDto_Get elemento);
    }
}
