using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Controller.Base;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;
using Senai.Hroads.WebApi.Repositories;

namespace Senai.Hroads.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase, IStandardController<TipoUsuario> {
        IStandardRepository<TipoUsuario> _typeUserRepository { get; set; }

        public TipoUsuarioController() {
            _typeUserRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de tipos de usuário.</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get() {
            return Ok(_typeUserRepository.ListAll());
        }

        /// <summary>
        /// Busca apenas um tipo de usuário.
        /// </summary>
        /// <param name="id">O id do tipo de usuário que será buscado.</param>
        /// <returns>Retorna um objeto JSON, do tipo de usuário buscado.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_typeUserRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario newEntity) {
            _typeUserRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de usuário.
        /// </summary>
        /// <param name="id">O id do tipo de usuário escolhido a ser atualizado.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario newEntity) {
            _typeUserRepository.Update(id, newEntity);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de usuário.
        /// </summary>
        /// <param name="id">O id do tipo de usuário que será deletado.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _typeUserRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
