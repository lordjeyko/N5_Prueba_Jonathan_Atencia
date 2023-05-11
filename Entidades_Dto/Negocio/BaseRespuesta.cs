namespace Entidades_Dto.Negocio
{
    public class BaseRespuesta<TEntidad> where TEntidad : class
    {
        public TEntidad? Data { get; set; }

        private string? _mensaje;
        public string? Mensaje { get => esValido ? _mensaje : null; set => _mensaje = value; }
        public List<string> Errores { get; set; } = new List<string>();
        public bool esValido { get => !Errores.Any(); }
        public ECodigo Codigo { get; set; }
    }
}
