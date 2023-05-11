using AutoMapper;
using Entidades_Dto.Empleado;
using Microsoft.EntityFrameworkCore;
using N5_Data.Entidades.Empleados;
using N5_Data.Negocio.Implementacion;
using N5_Data.Repositorio.Interfaz;

namespace N5_Data.Repositorio.Implementacion
{
    public class EmpleadoRepositorio : BaseRepositorio<Empleado>, IEmpleadoRepositorio
    {
        public EmpleadoRepositorio(DB_Contexto contexto, IMapper mapeo) : base(contexto, mapeo)
        {
        }

        public async Task<EmpleadoDto_Get> Empleado_Crear(EmpleadoDto_Create elemento)
        {
            Empleado registro = _Mapeo.Map<Empleado>(elemento);
            var resultado = await Crear(registro, true);
            return _Mapeo.Map<EmpleadoDto_Get>(resultado);
        }

        public async Task<EmpleadoDto_Get> Empleado_Eliminar(EmpleadoDto_Get elemento)
        {
            Empleado registro = _Mapeo.Map<Empleado>(elemento);
            var resultado = await Eliminar(registro, true);
            return _Mapeo.Map<EmpleadoDto_Get>(resultado);
        }

        public async Task<EmpleadoDto_Get> Empleado_Modificar(EmpleadoDto_Get elemento)
        {
            Empleado registro = _Mapeo.Map<Empleado>(elemento);
            var resultado = await Modificar(registro, true);
            return _Mapeo.Map<EmpleadoDto_Get>(resultado);
        }

        public async Task<EmpleadoDto_Get> Empleado_Obtener_Id(Guid guid)
        {
            var resultado = await DbSetEntidad.AsNoTracking()
                                    .Include(y => y.Perfiles)
                                    .FirstOrDefaultAsync(r => r.uId == guid);
            return _Mapeo.Map<EmpleadoDto_Get>(resultado);
        }

        public async Task<List<EmpleadoDto_Get>> Empleado_Obtener_Todo()
        {
            var resultado = await DbSetEntidad.AsNoTracking()
                                    .Include(y => y.Perfiles)
                                    .ToListAsync();
            return _Mapeo.Map<List<EmpleadoDto_Get>>(resultado);
        }
    }
}
