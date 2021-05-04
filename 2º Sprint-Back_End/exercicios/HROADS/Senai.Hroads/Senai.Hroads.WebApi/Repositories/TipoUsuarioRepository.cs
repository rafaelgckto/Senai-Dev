using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class TipoUsuarioRepository : IStandardRepository<TipoUsuario> {
        HroadsContext ctx = new HroadsContext();

        public void Delete(int id) {
            ctx.TipoUsuarios.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListAll() {
            return ctx.TipoUsuarios.ToList();
        }

        public void Register(TipoUsuario newEntity) {
            ctx.TipoUsuarios.Add(newEntity);
            ctx.SaveChanges();
        }

        public TipoUsuario SearchById(int id) {
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Update(int id, TipoUsuario newEntity) {
            TipoUsuario typeUserSought = SearchById(id);

            if(typeUserSought != null) {
                typeUserSought.Tipo = newEntity.Tipo;
            }

            ctx.TipoUsuarios.Update(typeUserSought);
            ctx.SaveChanges();
        }
    }
}
