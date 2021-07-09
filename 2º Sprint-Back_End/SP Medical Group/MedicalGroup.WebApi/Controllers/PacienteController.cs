using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MedicalGroup.WebApi.Domains;
using MedicalGroup.WebApi.Interfaces.Controllers.Base;
using MedicalGroup.WebApi.Interfaces.Repositories.Base;
using MedicalGroup.WebApi.Repositories;
using System;

namespace MedicalGroup.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase, IStandardController<Paciente> {
        IStantardRepository<Paciente> _patientRepository { get; set; }

        public PacienteController() {
            _patientRepository = new PacienteRepository();
        }

        /// <summary>
        /// Deleta um paciente.
        /// </summary>
        /// <param name="id">O id do paciente que será deletado.</param>
        /// <returns>Retorna StatusCode 204(No Content).</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                _patientRepository.Delete(id);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos os pacientes.
        /// </summary>
        /// <returns>Retorna um objeto JSON, com a lista de pacientes.</returns>
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_patientRepository.ListAll());
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca apenas um paciente.
        /// </summary>
        /// <param name="id">O id do paciente que será buscado.</param>
        /// <returns>Retorna um objeto JSON, do paciente buscado.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_patientRepository.SearchById(id));
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="newEntity">Objeto que será cadastrado.</param>
        /// <returns>Retorna um StatusCode 201(Created).</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Paciente newEntity) {
            try {
                _patientRepository.Register(newEntity);

                return StatusCode(201);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um paciente.
        /// </summary>
        /// <param name="id">O id do paciente escolhido a ser atualizado.</param>
        /// <param name="newEntity">Objeto com as novas informações.</param>
        /// <returns>Retorna um StatusCode 204(No Content).</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente newEntity) {
            try {
                _patientRepository.Update(id, newEntity);

                return StatusCode(204);
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }
    }
}
