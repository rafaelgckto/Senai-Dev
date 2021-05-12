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
    public class EnderecoController : ControllerBase, IStandardController<Endereco> {
        IStantardRepository<Endereco> _addressRepository { get; set; }

        public EnderecoController() {
            _addressRepository = new EnderecoRepository();
        }

        /// <summary>
        /// Deleta um endereço.
        /// </summary>
        /// <param name="id">O id do endereço que será deletado.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                _addressRepository.Delete(id);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos os endereços.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de endereços.</returns>
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_addressRepository.ListAll());
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca apenas um endereço.
        /// </summary>
        /// <param name="id">O id do endereço que será buscado.</param>
        /// <returns>Retorna um objeto JSON, do endereço buscado.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_addressRepository.SearchById(id));
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo endereço.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [HttpPost]
        public IActionResult Post(Endereco newEntity) {
            try {
                _addressRepository.Register(newEntity);

                return StatusCode(201);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um endereço.
        /// </summary>
        /// <param name="id">O id do endereço escolhido a ser atualizado.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Endereco newEntity) {
            try {
                _addressRepository.Update(id, newEntity);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }
    }
}
