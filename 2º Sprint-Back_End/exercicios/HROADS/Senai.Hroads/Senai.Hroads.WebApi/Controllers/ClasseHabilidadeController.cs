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
    public class ClasseHabilidadeController : ControllerBase, IClasseHabilidadeController {
        IClasseHabilidadeRepository _classSkillRepository { get; set; }

        public ClasseHabilidadeController() {
            _classSkillRepository = new ClasseHabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as classes e habilidades, que sejam correspondentes.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de classes e habilidades.</returns>
        [HttpGet("corresponding")]
        public IActionResult GetCorresponding() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lista todas as classes e habilidades, que não sejam correspondentes.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de classes e habilidades.</returns>
        [HttpGet("not-corresponding")]
        public IActionResult GetNotCorresponding() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lista todas as classes e habilidades.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de classes e habilidades.</returns>
        [HttpGet]
        public IActionResult Get() {
            return Ok(_classSkillRepository.ListAll());
        }

        /// <summary>
        /// Busca um registro(classe e habilidade).
        /// </summary>
        /// <param name="id">O id da classe e habilidade a ser buscado.</param>
        /// <returns>Retorna um objeto JSON, da classe buscada.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_classSkillRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra um registro(classe e habilidade).
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ClasseHabilidade newEntity) {
            _classSkillRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um registro(classe e habilidade).
        /// </summary>
        /// <param name="id">O id registro escolhido a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClasseHabilidade newEntity) {
            _classSkillRepository.Update(id, newEntity);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um registro(classe e habilidade).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _classSkillRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
