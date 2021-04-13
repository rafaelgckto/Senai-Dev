using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;

namespace Senai.Peoples.WebApi.Controllers {
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos funcionários.
    /// </summary>
    [Produces("application/json")] // Define que o tipo de resposta da API será no formato JSON
    [Route("api/[controller]")] // Define que a rota de uma requisição será no formato 'dominio/api/nomeController' Ex.: http://localhost:5000/api/funcionario
    [ApiController] // Define que é um controlador de API
    public class FuncionarioController : ControllerBase {
        /// <summary>
        /// Objeto '_employeeRepository' que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        IFuncionarioRepository _employeeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto '_employeeRepository' para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionarioController() {
            _employeeRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionários.
        /// </summary>
        /// <returns>Uma lista de funcionários e um status code.</returns>
        [HttpGet]
        public ActionResult Get() {
            List<Funcionario> listEmployee = _employeeRepository.Get();

            return Ok(listEmployee);
        }

        /// <summary>
        /// Busca um funcionário através do seu 'id'.
        /// </summary>
        /// <param name="id">O 'id' do funcionário que será buscado.</param>
        /// <returns>Um funcionário buscado ou 'NotFound', caso nenhum funcionário seja encontrado.</returns>
        [HttpGet("{id}")]
        public ActionResult GetById(int id) {
            Funcionario soughtEmployee = _employeeRepository.GetById(id);

            if(soughtEmployee == null)
                return NotFound("Nenhum funcionário foi encontrado.");

            return Ok(soughtEmployee);
        }

        /// <summary>
        /// Busca um funcionário através do seu 'nome'.
        /// </summary>
        /// <param name="nameEmployee">O 'nameEmployee' do funcionário que será buscado.</param>
        /// <returns>Um funcionário buscado ou 'NotFound', caso nenhum funcionário seja encontrado.</returns>
        [HttpGet("search/{nameEmployee}")]
        public ActionResult GetByName(string nameEmployee) {
            Funcionario soughtEmployee = _employeeRepository.GetByName(nameEmployee);
            
            if(soughtEmployee == null)
                return NotFound("Nenhum funcionário foi encontrado.");

            return Ok(soughtEmployee);
        }

        /// <summary>
        /// Lista todos os funcionários, exibindo o nome completo.
        /// </summary>
        /// <returns>A lista de funcionários com nome completo.</returns>
        [HttpGet("fullName")]
        public ActionResult FullName() {
            List<Funcionario> listEmployee = _employeeRepository.GetFullName();

            return Ok(listEmployee);
        }

        /// <summary>
        /// Lista todos os funcionários em ordem crescente ou decrescente(ASC - ascending ou DESC - descending).
        /// </summary>
        /// <param name="order">O tipo de ordem que será buscado.</param>
        /// <returns>A lista de funcionários na ordem escolhida.</returns>
        [HttpGet("ordination/{order}")]
        public ActionResult GetOrder(string order) {
            List<Funcionario> listEmployee = _employeeRepository.GetOrdination(order);

            if(order != "ASC" && order != "DESC") {
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'ASC' ou 'DESC'");
            }

            return Ok(listEmployee);
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="employee">Objeto 'employee' recebido na aquisição.</param>
        /// <returns>Um status code 201 Created.E um novo funcionário cadastrado.</returns>
        [HttpPost]
        public ActionResult Post(Funcionario employee) {
            _employeeRepository.Insert(employee);

            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(Funcionario employee) {
            Funcionario soughtEmployee = _employeeRepository.GetById(employee.idFuncionario);

            if(soughtEmployee != null) {
                try {
                    _employeeRepository.Update(employee);

                    return NoContent();
                }
                catch(Exception error) {
                    return BadRequest(error);
                }
            }

            return NotFound(new {
                message = "Funcionário não encontrado."
            });
        }

        /// <summary>
        /// Atualiza um funcionário existente passando o seu 'id' pelo corpo da requisição.
        /// </summary>
        /// <param name="id">O 'id' do funcionário que será atualizado.</param>
        /// <param name="employee">Objeto 'employee' com as novas informações.</param>
        /// <returns>O funcionário escolhido atualizado.</returns>
        [HttpPut("{id}")]
        public ActionResult PutId(int id, Funcionario employee) {
            Funcionario soughtEmployee = _employeeRepository.GetById(id);

            if(soughtEmployee == null) {
                return NotFound(new {
                    message = "Funcionário não encontrado.",
                    error = true
                });
            }

            try {
                _employeeRepository.UpdateIdUrl(id, employee);

                return NoContent();
            }
            catch(Exception error) {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um funcionário existente.
        /// </summary>
        /// <param name="id">O 'id' do funcionário que será deletado.</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _employeeRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
