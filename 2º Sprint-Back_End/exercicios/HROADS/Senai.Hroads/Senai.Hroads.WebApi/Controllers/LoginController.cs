using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using Senai.Hroads.WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Senai.Hroads.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {
        IUsuarioRepository _userRepository { get; set; }

        public LoginController() {
            _userRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário.
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário.</param>
        /// <returns>Retorna um token com as informações do usuário.</returns>
        [HttpPost]
        public IActionResult PostLogin(Usuario login) {
            Usuario searchedUser = _userRepository.Login(login.Email, login.Senha); // Busca o usuário pelo e-mail e senha.

            // Caso não encontre nenhum usuário com o e-mail e senha informados.
            if(searchedUser == null)
                return NotFound("E-mail ou senha inválidos."); // Retorna 'NotFound' com uma mensagem personalizada.

            // Define os dados que serão fornecidos no token - Payload.
            var claims = new[] {
                // Formato da Claim = TipoDaClaim, ValorDaClaim.
                new Claim(JwtRegisteredClaimNames.Email, searchedUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, searchedUser.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, searchedUser.IdTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Valor teste")
            };

            // Define a chave de acesso ao token.
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao"));

            // Define as credenciais do token - Header.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token.
            var token = new JwtSecurityToken(
                issuer: "Hroads.webApi", // Emissor do token.
                audience: "Hroads.webApi", // Destinatário do token.
                claims: claims, // Dados definidos acima.
                expires: DateTime.Now.AddMinutes(30), // Tempo de expiração.
                signingCredentials: creds // Credenciais do token.
            );

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
