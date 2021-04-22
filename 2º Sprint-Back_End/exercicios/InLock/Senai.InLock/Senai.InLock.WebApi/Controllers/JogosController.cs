using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Interfaces.Controller;
using Senai.InLock.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase, IJogosController {
        IJogosRepository _gameRepository { get; set; }

        public JogosController() {
            _gameRepository = new JogosRepository();
        }

        // http://localhost:5000/api/jogos
        // http://localhost:5000/swagger/

        /// <summary>
        /// Lista todos jogos com seus respectivos estúdios.
        /// </summary>
        /// <returns>Retorna todos os jogos com seus estúdios.</returns>
        [Authorize]
        [HttpGet("gameStudio")]
        public IActionResult GetGamesStudios() {
            List<JogosDomain> listGames = _gameRepository.ListGamesStudios();

            return Ok(listGames);
        }

        [HttpGet]
        public IActionResult Get() {
            throw new System.NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Cadastra um novo jogo.
        /// </summary>
        /// <param name="newTEntity">Novo objeto.</param>
        /// <returns>Retorna um novo jogo cadastrado e um status code 201.</returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(JogosDomain newTEntity) {
            _gameRepository.Register(newTEntity);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(JogosDomain newTEntity) {
            throw new System.NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            throw new System.NotImplementedException();
        }
    }
}
