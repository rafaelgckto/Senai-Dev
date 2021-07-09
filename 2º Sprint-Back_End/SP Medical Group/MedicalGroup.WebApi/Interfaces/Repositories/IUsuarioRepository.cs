using MedicalGroup.WebApi.Domains;
using MedicalGroup.WebApi.Interfaces.Repositories.Base;

namespace MedicalGroup.WebApi.Interfaces.Repositories {
    interface IUsuarioRepository : IStantardRepository<Usuario> {
        Usuario Login(string email, string password);
    }
}
