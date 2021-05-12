using Senai.SP_MG.WebApi.Domain;
using Senai.SP_MG.WebApi.Interfaces.Repositories.Base;

namespace Senai.SP_MG.WebApi.Interfaces.Repositories {
    interface IUsuarioRepository : IStantardRepository<Usuario> {
        Usuario Login(string email, string password);
    }
}
