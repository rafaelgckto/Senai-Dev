using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces.Controller {
    interface IJogosController : IStandardController<JogosDomain> {
        IActionResult GetGamesStudios();
    }
}
