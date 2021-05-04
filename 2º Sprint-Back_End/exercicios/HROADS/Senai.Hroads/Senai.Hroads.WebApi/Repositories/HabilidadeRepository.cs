using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class HabilidadeRepository : IHabilidadeRepository {
        HroadsContext ctx = new HroadsContext();

        public Habilidade AmountSkills() {
            throw new System.NotImplementedException();
        }

        public List<Habilidade> AscendingOrderById() {
            throw new System.NotImplementedException();
        }

        public List<Habilidade> ListSkillsAndTypes() {
            throw new System.NotImplementedException();
        }

        public List<Habilidade> ListAll() {
            return ctx.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).ToList();
        }

        public Habilidade SearchById(int id) {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        public void Register(Habilidade newEntity) {
            ctx.Habilidades.Add(newEntity);
            ctx.SaveChanges();
        }

        public void Update(int id, Habilidade newEntity) {
            Habilidade skillSought = ctx.Habilidades.Find(id);

            if(skillSought != null) {
                skillSought.Nome = newEntity.Nome;
                skillSought.IdTipoHabilidade = newEntity.IdTipoHabilidade;
            }

            ctx.Habilidades.Update(skillSought);
            ctx.SaveChanges();
        }

        public void Delete(int id) {
            Habilidade skillSought = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(skillSought);
            ctx.SaveChanges();
        }
    }
}
