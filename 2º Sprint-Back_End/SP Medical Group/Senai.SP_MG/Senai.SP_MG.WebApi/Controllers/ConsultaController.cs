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
    public class ConsultaController : ControllerBase, IStandardController<Consulta> {
        IStantardRepository<Consulta> _queryRepository { get; set; }

        public ConsultaController() {
            _queryRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Deleta uma consulta.
        /// </summary>
        /// <param name="id">O id da consulta que será deletada.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                _queryRepository.Delete(id);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todas as consultas.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de consulta.</returns>
        [Authorize(Roles = "2,3")]
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_queryRepository.ListAll());
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca apenas uma consulta.
        /// </summary>
        /// <param name="id">O id da consulta que será buscada.</param>
        /// <returns>Retorna um objeto JSON, da consulta buscada.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_queryRepository.SearchById(id));
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Consulta newEntity) {
            try {
                _queryRepository.Register(newEntity);

                return StatusCode(201);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma consulta.
        /// </summary>
        /// <param name="id">O id da consulta escolhida a ser atualizada.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta newEntity) {
            try {
                _queryRepository.Update(id, newEntity);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }
    }
}
