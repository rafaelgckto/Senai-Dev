using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class TipoHabilidadeRepository : IStandardRepository<TipoHabilidade> {
        HroadsContext ctx = new HroadsContext();

        public void Delete(int id) {
            ctx.TipoHabilidades.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListAll() {
            return ctx.TipoHabilidades.ToList();
        }

        public void Register(TipoHabilidade newEntity) {
            ctx.TipoHabilidades.Add(newEntity);
            ctx.SaveChanges();
        }

        public TipoHabilidade SearchById(int id) {
            return ctx.TipoHabilidades.FirstOrDefault(th => th.IdTipoHabilidade == id);
        }

        public void Update(int id, TipoHabilidade newEntity) {
            TipoHabilidade typeSkillSought = SearchById(id);

            if(typeSkillSought != null) {
                typeSkillSought.Tipo = newEntity.Tipo;
            }

            ctx.TipoHabilidades.Update(typeSkillSought);
            ctx.SaveChanges();
        }
    }
}
