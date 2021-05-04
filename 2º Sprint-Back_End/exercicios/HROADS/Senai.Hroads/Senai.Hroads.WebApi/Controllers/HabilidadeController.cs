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
    public class HabilidadeController : ControllerBase, IHabilidadeController {
        IHabilidadeRepository _skillRepository { get; set; }

        public HabilidadeController() {
            _skillRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista a quantidade de habilidades.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a quantidade de habilidades.</returns>
        [HttpGet("amount-skills")]
        public IActionResult GetAmountSkills() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lista as habilidades, de forma ascendente pelo Id.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de habilidades ordenada de forma ascendente.</returns>
        [HttpGet("order/byId/asc")]
        public IActionResult GetAscendingOrderById() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lista as habilidades e os tipos das habilidades.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de habilidades e tipos de habilidades.</returns>
        [HttpGet("skill&types")]
        public IActionResult GetSkillsAndTypes() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lista todas as habilidades.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de classes.</returns>
        [HttpGet]
        public IActionResult Get() {
            return Ok(_skillRepository.ListAll());
        }

        /// <summary>
        /// Busca apenas uma habilidade.
        /// </summary>
        /// <param name="id">O id da habilidade que será buscada.</param>
        /// <returns>Retorna um objeto JSON, da classe buscada.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_skillRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra uma nova habilidade.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade newEntity) {
            _skillRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma habilidade.
        /// </summary>
        /// <param name="id">O id da habilidade escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade newEntity) {
            _skillRepository.Update(id, newEntity);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma habilidade.
        /// </summary>
        /// <param name="id">O id da habilidade que será deletada.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _skillRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
