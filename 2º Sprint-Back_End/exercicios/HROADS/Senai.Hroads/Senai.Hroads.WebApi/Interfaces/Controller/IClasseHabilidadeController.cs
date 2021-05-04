using Microsoft.AspNetCore.Mvc;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Controller.Base;

namespace Senai.Hroads.WebApi.Interfaces.Controller {
    interface IClasseHabilidadeController : IStandardController<ClasseHabilidade> {
        IActionResult GetCorresponding();
        IActionResult GetNotCorresponding();
    }
}
