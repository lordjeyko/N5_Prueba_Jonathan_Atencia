using Entidades_Dto.Empleado;
using Entidades_Dto.Negocio;
using Entidades_Dto.Perfiles;
using N5_Data.Negocio.Interfaz;
using N5_Data.Repositorio.Interfaz;
using N5_Negocio.Negocio.Abstracto;

namespace N5_Data.Repositorio.Implementacion
{
    public class PerfilNegocio : BaseNegocio, IPerfilNegocio
    {
        public PerfilNegocio(IUnidadDeTrabajo unidad) : base(unidad)
        {
        }

        public async Task<BaseRespuesta<PerfilDto_Get>> CrearPerfil(PerfilDto_Create elemento)
        {
            var respuesta = new BaseRespuesta<PerfilDto_Get>();
            try
            {
                if (!(await _Unidad.Rol.Existe(r => r.uId == elemento.RolId)))
                {
                    respuesta.Errores.Add($"El identificador de permiso enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                if (!(await _Unidad.Empleado.Existe(r => r.uId == elemento.UsuarioId)))
                {
                    respuesta.Errores.Add($"El identificador de usuario enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                respuesta.Data = await _Unidad.Perfil.Perfil_Crear(elemento);
                respuesta.Mensaje = $"El Perfil, se creo correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<RolDto_Get>> CrearRol(RolDto_Create elemento)
        {
            var respuesta = new BaseRespuesta<RolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Rol.Rol_Crear(elemento);
                respuesta.Mensaje = $"El Rol {respuesta.Data.Nombre}, se creo correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<TipoRolDto_Get>> CrearTipoRol(TipoRolDto_Create elemento)
        {
            var respuesta = new BaseRespuesta<TipoRolDto_Get>();
            try
            {
                if (!(await _Unidad.Rol.Existe(r => r.uId == elemento.PermisoId)))
                {
                    respuesta.Errores.Add($"El identificador de permiso enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                respuesta.Data = await _Unidad.TipoRol.TipoRol_Crear(elemento);
                respuesta.Mensaje = $"El Tipo de Rol {respuesta.Data.Nombre}, " +
                    $"se creo correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<PerfilDto_Get>> EliminarPerfil(PerfilDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<PerfilDto_Get>();
            try
            {
                if (!(await _Unidad.Rol.Existe(r => r.uId == elemento.RolId)))
                {
                    respuesta.Errores.Add($"El identificador de permiso enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                if (!(await _Unidad.Empleado.Existe(r => r.uId == elemento.UsuarioId)))
                {
                    respuesta.Errores.Add($"El identificador de usuario enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                respuesta.Data = await _Unidad.Perfil.Perfil_Eliminar(elemento);
                respuesta.Mensaje = $"El Perfil, se elimino correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<RolDto_Get>> EliminarRol(RolDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<RolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Rol.Rol_Eliminar(elemento);
                respuesta.Mensaje = $"El rol se elimino correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<TipoRolDto_Get>> EliminarTipoRol(TipoRolDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<TipoRolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.TipoRol.TipoRol_Eliminar(elemento);
                respuesta.Mensaje = $"El tipo de rol se elimino correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<List<RolDto_Get>>> ListaRoles()
        {
            var respuesta = new BaseRespuesta<List<RolDto_Get>>();
            try
            {
                respuesta.Data = await _Unidad.Rol.Rol_Obtener_Todo();
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

        public async Task<BaseRespuesta<List<TipoRolDto_Get>>> ListaTipoRol()
        {
            var respuesta = new BaseRespuesta<List<TipoRolDto_Get>>();
            try
            {
                respuesta.Data = await _Unidad.TipoRol.TipoRol_Obtener_Todo();
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

        public async Task<BaseRespuesta<PerfilDto_Get>> ModificarPerfil(PerfilDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<PerfilDto_Get>();
            try
            {
                if (!(await _Unidad.Rol.Existe(r => r.uId == elemento.RolId)))
                {
                    respuesta.Errores.Add($"El identificador de permiso enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                if (!(await _Unidad.Empleado.Existe(r => r.uId == elemento.UsuarioId)))
                {
                    respuesta.Errores.Add($"El identificador de usuario enviado no " +
                        $"corresponde a uno registrado, valide.");
                    respuesta.Codigo = ECodigo.BadRequest;
                }

                respuesta.Data = await _Unidad.Perfil.Perfil_Modificar(elemento);
                respuesta.Mensaje = $"El Perfil, se modifico correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<RolDto_Get>> ModificarRol(RolDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<RolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Rol.Rol_Modificar(elemento);
                respuesta.Mensaje = $"El rol {respuesta.Data.Nombre}" +
                    $", se actualizo correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<TipoRolDto_Get>> ModificarTipoRol(TipoRolDto_Get elemento)
        {
            var respuesta = new BaseRespuesta<TipoRolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.TipoRol.TipoRol_Modificar(elemento);
                respuesta.Mensaje = $"El tipo rol {respuesta.Data.Nombre}" +
                    $", se actualizo correctamente!";
                respuesta.Codigo = ECodigo.Ok;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<RolDto_Get>> ObtenerRol(Guid guid)
        {
            var respuesta = new BaseRespuesta<RolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.Rol.Rol_Obtener_Id(guid);
                respuesta.Mensaje = $"Se ejecuto correctamente!";
                if (respuesta.Data != null)
                    respuesta.Codigo = ECodigo.Ok;
                else
                    respuesta.Codigo = ECodigo.NoFound;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }

        public async Task<BaseRespuesta<TipoRolDto_Get>> ObtenerTipoRol(Guid guid)
        {
            var respuesta = new BaseRespuesta<TipoRolDto_Get>();
            try
            {
                respuesta.Data = await _Unidad.TipoRol.TipoRol_Obtener_Id(guid);
                respuesta.Mensaje = $"Se ejecuto correctamente!";
                if (respuesta.Data != null)
                    respuesta.Codigo = ECodigo.Ok;
                else
                    respuesta.Codigo = ECodigo.NoFound;
            }
            catch (Exception ex)
            {
                respuesta.Errores.Add(ex.Message);
                respuesta.Codigo = ECodigo.ServerError;
            }

            return respuesta;
        }
    }
}
