namespace N5_Data.Repositorio.Interfaz
{
    using Entidades_Dto.Negocio;
    using Entidades_Dto.Perfiles;

    public interface IPerfilNegocio
    {
        Task<BaseRespuesta<List<RolDto_Get>>> ListaRoles();
        Task<BaseRespuesta<RolDto_Get>> ObtenerRol(Guid guid);
        Task<BaseRespuesta<RolDto_Get>> CrearRol(RolDto_Create elemento);
        Task<BaseRespuesta<RolDto_Get>> ModificarRol(RolDto_Get elemento);
        Task<BaseRespuesta<RolDto_Get>> EliminarRol(RolDto_Get elemento);

        Task<BaseRespuesta<List<TipoRolDto_Get>>> ListaTipoRol();
        Task<BaseRespuesta<TipoRolDto_Get>> ObtenerTipoRol(Guid guid);
        Task<BaseRespuesta<TipoRolDto_Get>> CrearTipoRol(TipoRolDto_Create elemento);
        Task<BaseRespuesta<TipoRolDto_Get>> ModificarTipoRol(TipoRolDto_Get elemento);
        Task<BaseRespuesta<TipoRolDto_Get>> EliminarTipoRol(TipoRolDto_Get elemento);

        Task<BaseRespuesta<PerfilDto_Get>> CrearPerfil(PerfilDto_Create elemento);
        Task<BaseRespuesta<PerfilDto_Get>> ModificarPerfil(PerfilDto_Get elemento);
        Task<BaseRespuesta<PerfilDto_Get>> EliminarPerfil(PerfilDto_Get elemento);
    }
}
