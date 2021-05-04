using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;

namespace Senai.Hroads.WebApi.Interfaces.Repositories {
    interface IUsuarioRepository : IStandardRepository<Usuario> {
        Usuario Login(string email, string password);
    }
}
