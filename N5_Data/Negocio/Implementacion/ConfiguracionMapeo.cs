using AutoMapper;
using Entidades_Dto.Empleado;
using Entidades_Dto.Perfiles;
using N5_Data.Entidades.Empleados;
using N5_Data.Entidades.Perfiles;

namespace N5_Data.Negocio.Implementacion
{
    public class ConfiguracionMapeo : Profile
    {
        public ConfiguracionMapeo()
        {
           CreateMap<Empleado, EmpleadoDto_Get>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.uId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cNombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.cApellido))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.cCelular))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.cDocumento))
                .ReverseMap();
           CreateMap<Empleado, EmpleadoDto_Create>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cNombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.cApellido))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.cCelular))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.cDocumento))
                .ReverseMap();

            CreateMap<Rol, RolDto_Get>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.uId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cNombre))
                .ReverseMap();
            CreateMap<Rol, RolDto_Create>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cNombre))
                .ReverseMap();

            CreateMap<TipoRol, TipoRolDto_Get>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.uId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cNombre))
                .ForMember(dest => dest.PermisoId, opt => opt.MapFrom(src => src.Rol.uId))
                .ReverseMap();
            CreateMap<TipoRol, TipoRolDto_Create>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cNombre))
                .ForMember(dest => dest.PermisoId, opt => opt.MapFrom(src => src.Rol.uId))
                .ReverseMap();

            CreateMap<PerfilUsuario, PerfilDto_Get>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.uId))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.uUsuarioId.uId))
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.uRolId.uId))
                .ReverseMap();
            CreateMap<PerfilUsuario, PerfilDto_Create>()
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.uUsuarioId.uId))
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.uRolId.uId))
                .ReverseMap();

        }
    }
}
