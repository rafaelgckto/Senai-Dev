using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class ClasseRepository : IClasseRepository {
        HroadsContext ctx = new HroadsContext();

        public void Delete(int id) {
            ctx.Classes.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Classe> ListAll() {
            return ctx.Classes.ToList();
        }

        public List<Classe> ListNames() {
            throw new System.NotImplementedException();
        }

        public void Register(Classe newEntity) {
            ctx.Classes.Add(newEntity);
            ctx.SaveChanges();
        }

        public Classe SearchById(int id) {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Update(int id, Classe newEntity) {
            Classe classSought = SearchById(id);

            if(classSought != null) {
                classSought.Nome = newEntity.Nome;
            }

            ctx.Classes.Update(classSought);
            ctx.SaveChanges();
        }
    }
}
