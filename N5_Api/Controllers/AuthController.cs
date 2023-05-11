using Entidades_Dto.Empleado;
using Entidades_Dto.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using N5_Data.Repositorio.Interfaz;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N5_Api.Controllers
{
    /// <summary>
    /// Solicitud de credenciales
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Permite genear el Token Jwt, siempre y cuando se envie correctamente la información
        /// </summary>
        /// <returns>Listado de empleados</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<TokenDto> Auth([FromBody] UsuarioDto usuario)
        {
            if (usuario.clave == configuration["Registro"])
                return StatusCode(200, ContruirToken(usuario));
            else
                return BadRequest(new TokenDto());

        }

        private TokenDto ContruirToken (UsuarioDto usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", usuario.correo)

            };
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddHours(8);
            var token = new JwtSecurityToken(issuer: null, 
                audience: null, 
                claims: claims, 
                expires: expiracion,
                signingCredentials: credenciales);

            return new TokenDto() { 
                token = new JwtSecurityTokenHandler().WriteToken(token), 
                expira = expiracion
            };
        }

    }
}
