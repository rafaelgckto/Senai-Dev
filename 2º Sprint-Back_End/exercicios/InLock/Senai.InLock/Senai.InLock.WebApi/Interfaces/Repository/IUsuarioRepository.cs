using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces {
    interface IUsuarioRepository : IStandardRepository<UsuarioDomain> {
        UsuarioDomain Login(string email, string password);
    }
}
