using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Controller;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using Senai.Hroads.WebApi.Repositories;

namespace Senai.Hroads.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase, IClasseController {
        IClasseRepository _classRepository { get; set; }
        
        public ClasseController() {
            _classRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista, somente, os nome de todas as classes.
        /// </summary>
        /// <returns>Retorna uma lista JSON, com os nomes das classes.</returns>
        [HttpGet("names")]
        public IActionResult GetNames() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lista todas as classes.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de classes.</returns>
        [HttpGet]
        public IActionResult Get() {
            return Ok(_classRepository.ListAll());
        }

        /// <summary>
        /// Busca apenas uma classe.
        /// </summary>
        /// <param name="id">O id da classe que será buscada.</param>
        /// <returns>Retorna um objeto JSON, da classe buscada.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_classRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra uma nova classe.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe newEntity) {
            _classRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma classe.
        /// </summary>
        /// <param name="id">O id da classe escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe newEntity) {
            _classRepository.Update(id, newEntity);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma classe.
        /// </summary>
        /// <param name="id">O id da classe que será deletada.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _classRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
