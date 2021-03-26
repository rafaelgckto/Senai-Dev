using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;

namespace Senai.Peoples.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase {
        IFuncionarioRepository _employeeRepository { get; set; }

        public FuncionarioController() {
            _employeeRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public ActionResult Get() {
            List<Funcionario> listEmployee = _employeeRepository.Get();

            return Ok(listEmployee);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id) {
            Funcionario soughtEmployee = _employeeRepository.GetById(id);

            if(soughtEmployee == null)
                return NotFound("Nenhum funcionário foi encontrado.");

            return Ok(soughtEmployee);
        }

        [HttpPost]
        public ActionResult Post(Funcionario employee) {
            _employeeRepository.Insert(employee);

            return StatusCode(201);
        }

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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            _employeeRepository.Delete(id);

            return StatusCode(204);
        }
    }
}
