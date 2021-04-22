using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces.Controller {
    interface IUsuarioController : IStandardController<UsuarioDomain> {
        IActionResult Login(UsuarioDomain login);
    }
}
