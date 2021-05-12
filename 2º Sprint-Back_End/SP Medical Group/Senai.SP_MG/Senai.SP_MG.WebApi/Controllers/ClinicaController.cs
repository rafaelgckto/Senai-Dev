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
    public class ClinicaController : ControllerBase, IStandardController<Clinica> {
        IStantardRepository<Clinica> _clinicRepository { get; set; }

        public ClinicaController() {
            _clinicRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Deleta uma clinica.
        /// </summary>
        /// <param name="id">O id da clinica que será deletada.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                _clinicRepository.Delete(id);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos as clinicas.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de clinicas.</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_clinicRepository.ListAll());
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca apenas uma clinica.
        /// </summary>
        /// <param name="id">O id da clinica que será buscada.</param>
        /// <returns>Retorna um objeto JSON, da clinica buscada.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_clinicRepository.SearchById(id));
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova clinica.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica newEntity) {
            try {
                _clinicRepository.Register(newEntity);

                return StatusCode(201);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma clinica.
        /// </summary>
        /// <param name="id">O id da clinica escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica newEntity) {
            try {
                _clinicRepository.Update(id, newEntity);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }
    }
}
