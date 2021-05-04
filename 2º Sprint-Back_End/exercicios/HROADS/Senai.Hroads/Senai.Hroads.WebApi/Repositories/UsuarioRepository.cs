using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        HroadsContext ctx = new HroadsContext();

        public void Delete(int id) {
            ctx.Usuarios.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListAll() {
            return ctx.Usuarios.Include(p => p.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Login(string email, string password) {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == password);
        }

        public void Register(Usuario newEntity) {
            ctx.Usuarios.Add(newEntity);
            ctx.SaveChanges();
        }

        public Usuario SearchById(int id) {
            return ctx.Usuarios.FirstOrDefault(p => p.IdUsuario == id);
        }

        public void Update(int id, Usuario newEntity) {
            Usuario soughtUser = SearchById(id);

            if(soughtUser != null) {
                soughtUser.Email = newEntity.Email;
                soughtUser.Senha = newEntity.Senha;
                soughtUser.IdTipoUsuario = newEntity.IdTipoUsuario;
            }

            ctx.Usuarios.Update(soughtUser);
            ctx.SaveChanges();
        }
    }
}
