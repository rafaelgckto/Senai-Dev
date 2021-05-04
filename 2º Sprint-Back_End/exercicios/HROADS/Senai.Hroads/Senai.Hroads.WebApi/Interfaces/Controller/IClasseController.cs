using Microsoft.AspNetCore.Mvc;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Controller.Base;

namespace Senai.Hroads.WebApi.Interfaces.Controller {
    interface IClasseController : IStandardController<Classe> {
        IActionResult GetNames();
    }
}
