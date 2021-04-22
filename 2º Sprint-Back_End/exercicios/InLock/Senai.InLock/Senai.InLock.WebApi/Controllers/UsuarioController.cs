using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Interfaces.Controller;
using Senai.InLock.WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Senai.InLock.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")] // http://localhost:5000/api/usuario
    [ApiController]
    public class UsuarioController : ControllerBase, IUsuarioController {
        IUsuarioRepository _userRepository { get; set; }

        public UsuarioController() {
            _userRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login) {
            UsuarioDomain searchedUser = _userRepository.Login(login.email, login.senha); // Busca o usuário pelo e-mail e senha.

            // Caso não encontre nenhum usuário com o e-mail e senha informados.
            if(searchedUser == null)
                return NotFound("E-mail ou senha inválidos."); // Retorna 'NotFound' com uma mensagem personalizada.

            // Define os dados que serão fornecidos no token - Payload.
            var claims = new[] {
                // Formato da Claim = TipoDaClaim, ValorDaClaim.
                new Claim(JwtRegisteredClaimNames.Email, searchedUser.email),
                new Claim(JwtRegisteredClaimNames.Jti, searchedUser.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, searchedUser.idTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Valor teste")
            };

            // Define a chave de acesso ao token.
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

            // Define as credenciais do token - Header.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token.
            var token = new JwtSecurityToken(
                issuer: "InLock.webApi", // Emissor do token.
                audience: "InLock.webApi", // Destinatário do token.
                claims: claims, // Dados definidos acima.
                expires: DateTime.Now.AddMinutes(30), // Tempo de expiração.
                signingCredentials: creds // Credenciais do token.
            );

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [HttpGet]
        public IActionResult Get() {
            throw new System.NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain newTEntity) {
            throw new System.NotImplementedException();
        }

        [HttpPut]
        public IActionResult Put(UsuarioDomain newTEntity) {
            throw new System.NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            throw new System.NotImplementedException();
        }
    }
}
