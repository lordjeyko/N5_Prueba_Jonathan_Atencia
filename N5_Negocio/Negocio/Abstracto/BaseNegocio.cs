using N5_Data.Negocio.Interfaz;

namespace N5_Negocio.Negocio.Abstracto
{
    public abstract class BaseNegocio
    {
        protected readonly IUnidadDeTrabajo _Unidad;
        public BaseNegocio(IUnidadDeTrabajo unidad) => _Unidad = unidad;
    }
}
