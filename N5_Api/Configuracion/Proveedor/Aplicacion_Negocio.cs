namespace N5_Api.Configuracion.Proveedor
{
    using N5_Data.Repositorio.Implementacion;
    using N5_Data.Repositorio.Interfaz;
    public static class Aplicacion_Negocio
    {
        public static void Registro(this IServiceCollection services)
        {
            services.AddScoped<IEmpleadoNegocio, EmpleadoNegocio>();
            services.AddScoped<IPerfilNegocio, PerfilNegocio>();
        }
    }
}
