using Microsoft.EntityFrameworkCore;
using MedicalGroup.WebApi.Contexts;
using MedicalGroup.WebApi.Domains;
using MedicalGroup.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MedicalGroup.WebApi.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Usuarios.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListAll() {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string password) {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == password);
        }

        public void Register(Usuario newEntity) {
            ctx.Usuarios.Add(newEntity);
            ctx.SaveChanges();
        }

        public Usuario SearchById(int id) {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Update(int id, Usuario newEntity) {
            Usuario searchedUser = ctx.Usuarios.Find(id);

            if(searchedUser != null) {
                // UNDONE: searchedUser != null
            }

            ctx.Usuarios.Update(searchedUser);
            ctx.SaveChanges();
        }
    }
}
