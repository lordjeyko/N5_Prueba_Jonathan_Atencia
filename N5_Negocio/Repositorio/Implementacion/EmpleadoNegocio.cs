using Entidades_Dto.Empleado;
using Entidades_Dto.Negocio;
using N5_Data.Negocio.Interfaz;
using N5_Data.Repositorio.Interfaz;
using N5_Negocio.Negocio.Abstracto;

namespace N5_Data.Repositorio.Implementacion
{
    public class EmpleadoNegocio : BaseNegocio, IEmpleadoNegocio
    {
        public EmpleadoNegocio(IUnidadDeTrabajo unidad) : base(unidad)
        {
        }

        public async Task<BaseRespuesta<EmpleadoDto_Get>> CrearEmpleado(EmpleadoDto_Create elemento)
        {
            var respuesta = new BaseRespuesta<EmpleadoDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Empleado.Empleado_Crear(elemento);
                respuesta.Mensaje = $"El empleado {respuesta.Data.Nombre} " +
                    $"{respuesta.Data.Apellido}, se creo correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<EmpleadoDto_Get>> EliminarEmpleado(EmpleadoDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<EmpleadoDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Empleado.Empleado_Eliminar(elemento);
                respuesta.Mensaje = $"El empleado {respuesta.Data.Nombre} " +
                    $"{respuesta.Data.Apellido}, se elimino correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<List<EmpleadoDto_Get>>> ListaEmpleados()
        {
            var respuesta = new BaseRespuesta<List<EmpleadoDto_Get>>();
            try
            {
                respuesta.Data = await _Unidad.Empleado.Empleado_Obtener_Todo();
                respuesta.Mensaje = $"Se ejecuto correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<EmpleadoDto_Get>> ModificarEmpleado(EmpleadoDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<EmpleadoDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Empleado.Empleado_Modificar(elemento);
                respuesta.Mensaje = $"El empleado {respuesta.Data.Nombre} " +
                    $"{respuesta.Data.Apellido}, se modifico correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<EmpleadoDto_Get>> ObtenerEmpleado(Guid guid)
        {
            var respuesta = new BaseRespuesta<EmpleadoDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Empleado.Empleado_Obtener_Id(guid);
                respuesta.Mensaje = $"Se ejecuto correctamente!";
                if (respuesta.Data != null)
                    respuesta.Codigo = ECodigo.Ok;
                else
                    respuesta.Codigo = ECodigo.NoFound;

            }
            catch (Exception ex) { respuesta.Errores.Add(ex.Message); respuesta.Codigo = ECodigo.ServerError; }

            return respuesta;
        }

    }
}
