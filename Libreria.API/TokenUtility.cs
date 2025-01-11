using Compartido.DTOS.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obligatorio
{
    public static class TokenUtility
    {
        /// <summary>
        /// Genera un token JWT con claims personalizados.
        /// </summary>
        /// <param name="username">El nombre de usuario que deseamos guardar en el token.</param>
        /// <param name="roles">Roles que deseamos guardar en el token.</param>
        /// <returns>El token JWT generado.</returns>
        public static string GenerarToken(string email, string rol)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claveSecreta = "clave_larga_para_firmar_el_token_clave_segura";
            var claveCodificada = Encoding.ASCII.GetBytes(claveSecreta);

            // Crear los claims, incluyendo roles
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.Add(new Claim(ClaimTypes.Role, rol));

            // Descripción del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(claveCodificada),
                    SecurityAlgorithms.HmacSha256
                ),
                Issuer = "tu_issuer", // Define el issuer
                Audience = "tu_audience" // Define la audiencia
            };

            // Crear y devolver el token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
