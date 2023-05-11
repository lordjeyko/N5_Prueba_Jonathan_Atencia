namespace Entidades_Dto.Negocio
{
    public class UsuarioDto
    {
        public string correo { get; set; }
        public string clave { get; set; }
    }

    public class TokenDto
    {
        public string token { get; set; }
        public DateTime expira { get; set; }
    }
}
