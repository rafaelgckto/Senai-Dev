using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SP_MG.WebApi.Domain;
using Senai.SP_MG.WebApi.Interfaces.Controllers.Base;
using Senai.SP_MG.WebApi.Interfaces.Repositories.Base;
using Senai.SP_MG.WebApi.Repositories;
using System;

namespace Senai.SP_MG.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase, IStandardController<Medico> {
        IStantardRepository<Medico> _doctorRepository { get; set; }

        public MedicoController() {
            _doctorRepository = new MedicoRepository();
        }

        /// <summary>
        /// Deleta um médico.
        /// </summary>
        /// <param name="id">O id do médico que será deletado.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                _doctorRepository.Delete(id);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos os médicos.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de médicos.</returns>
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_doctorRepository.ListAll());
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca apenas um médico.
        /// </summary>
        /// <param name="id">O id do médico que será buscado.</param>
        /// <returns>Retorna um objeto JSON, do médico buscado.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_doctorRepository.SearchById(id));
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Medico newEntity) {
            try {
                _doctorRepository.Register(newEntity);

                return StatusCode(201);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um médico.
        /// </summary>
        /// <param name="id">O id do médico escolhido a ser atualizado.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico newEntity) {
            try {
                _doctorRepository.Update(id, newEntity);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }
    }
}
