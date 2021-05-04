using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository {
        HroadsContext ctx = new HroadsContext();

        public void Delete(int id) {
            ctx.ClasseHabilidades.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ListAll() {
            return ctx.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).ToList();
        }

        public List<ClasseHabilidade> ListCorresponding() {
            throw new System.NotImplementedException();
        }

        public List<ClasseHabilidade> ListNotCorresponding() {
            throw new System.NotImplementedException();
        }

        public void Register(ClasseHabilidade newEntity) {
            ctx.ClasseHabilidades.Add(newEntity);
            ctx.SaveChanges();
        }

        public ClasseHabilidade SearchById(int id) {
            return ctx.ClasseHabilidades.FirstOrDefault(ch => ch.IdClasseHabilidade == id);
        }

        public void Update(int id, ClasseHabilidade newEntity) {
            ClasseHabilidade classSkillSought = SearchById(id);

            if(classSkillSought != null) {
                classSkillSought.IdClasse = newEntity.IdClasse;
                classSkillSought.IdHabilidade = newEntity.IdHabilidade;
            }

            ctx.ClasseHabilidades.Update(classSkillSought);
            ctx.SaveChanges();
        }
    }
}
