using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Controller.Base;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using Senai.Hroads.WebApi.Repositories;

namespace Senai.Hroads.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase, IStandardController<Usuario> {
        IUsuarioRepository _userRepository { get; set; }

        public UsuarioController() {
            _userRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Deleta um usuário.
        /// </summary>
        /// <param name="id">O id do usuário que será deletado.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _userRepository.Delete(id);

            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de usuários.</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get() {
            return Ok(_userRepository.ListAll());
        }

        /// <summary>
        /// Busca apenas um usuário.
        /// </summary>
        /// <param name="id">O id do usuário que será buscado.</param>
        /// <returns>Retorna um objeto JSON, do usuário buscado.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_userRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(Usuario newEntity) {
            _userRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuário.
        /// </summary>
        /// <param name="id">O id da classe escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario newEntity) {
            _userRepository.Update(id, newEntity);

            return StatusCode(204);
        }
    }
}
