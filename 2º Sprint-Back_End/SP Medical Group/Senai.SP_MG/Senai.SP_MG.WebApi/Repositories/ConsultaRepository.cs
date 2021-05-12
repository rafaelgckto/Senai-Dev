using Senai.SP_MG.WebApi.Contexts;
using Senai.SP_MG.WebApi.Domain;
using Senai.SP_MG.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SP_MG.WebApi.Repositories {
    public class ConsultaRepository : IStantardRepository<Consulta> {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Consulta.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Consulta> ListAll() {
            return ctx.Consulta.ToList();
        }

        public void Register(Consulta newEntity) {
            ctx.Consulta.Add(newEntity);
            ctx.SaveChanges();
        }

        public Consulta SearchById(int id) {
            return ctx.Consulta.FirstOrDefault(con => con.IdConsulta == id);
        }

        public void Update(int id, Consulta newEntity) {
            Consulta fetchedQuery = ctx.Consulta.Find(id);

            if(fetchedQuery != null) {
                // UNDONE: fetchedQuery != null
            }

            ctx.Consulta.Update(fetchedQuery);
            ctx.SaveChanges();
        }
    }
}
