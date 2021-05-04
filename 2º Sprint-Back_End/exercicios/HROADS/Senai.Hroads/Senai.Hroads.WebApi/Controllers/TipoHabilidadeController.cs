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
    public class TipoHabilidadeController : ControllerBase, IStandardController<TipoHabilidade> {
        IStandardRepository<TipoHabilidade> _typeSkillRepository { get; set; }

        public TipoHabilidadeController() {
            _typeSkillRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos tipos de habilidade.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de tipos de habilidade.</returns>
        [HttpGet]
        public IActionResult Get() {
            return Ok(_typeSkillRepository.ListAll());
        }

        /// <summary>
        /// Busca apenas um tipo de habilidade.
        /// </summary>
        /// <param name="id">O id do tipo de habilidade que será buscado.</param>
        /// <returns>Retorna um objeto JSON, do tipo de habilidade buscado.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_typeSkillRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra uma nova tipo de habilidade.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade newEntity) {
            _typeSkillRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de habilidade.
        /// </summary>
        /// <param name="id">O id do tipo de habilidade escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade newEntity) {
            _typeSkillRepository.Update(id, newEntity);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de habilidade.
        /// </summary>
        /// <param name="id">O id do tipo de habilidade que será deletada.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _typeSkillRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
