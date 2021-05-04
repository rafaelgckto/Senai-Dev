using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Controller;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using Senai.Hroads.WebApi.Repositories;
using System;

namespace Senai.Hroads.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase, IPersonagemController {
        IPersonagemRepository _characterRepository { get; set; }

        public PersonagemController() {
            _characterRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os personagens, que sejam correspondentes.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de personagens.</returns>
        [Authorize]
        [HttpGet("corresponding")]
        public IActionResult GetCorresponding() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os personagens, que não sejam correspondentes.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de personagens.</returns>
        [Authorize]
        [HttpGet("not-corresponding")]
        public IActionResult GetNotCorresponding() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os personagens.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de personagens.</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get() {
            return Ok(_characterRepository.ListAll());
        }

        /// <summary>
        /// Busca apenas um personagem.
        /// </summary>
        /// <param name="id">O id do personagem que será buscado.</param>
        /// <returns>Retorna um objeto JSON, da classe buscada.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_characterRepository.SearchById(id));
        }

        /// <summary>
        /// Cadastra uma novo habilidade.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem newEntity) {
            _characterRepository.Register(newEntity);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um personagem.
        /// </summary>
        /// <param name="id">O id do personagem escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem newEntity) {
            _characterRepository.Update(id, newEntity);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um personagem.
        /// </summary>
        /// <param name="id">O id do personagem que será deletado.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _characterRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
