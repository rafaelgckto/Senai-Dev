using Senai.SP_MG.WebApi.Contexts;
using Senai.SP_MG.WebApi.Domain;
using Senai.SP_MG.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SP_MG.WebApi.Repositories {
    public class ClinicaRepository : IStantardRepository<Clinica> {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Clinicas.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Clinica> ListAll() {
            return ctx.Clinicas.ToList();
        }

        public void Register(Clinica newEntity) {
            ctx.Clinicas.Add(newEntity);
            ctx.SaveChanges();
        }

        public Clinica SearchById(int id) {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Update(int id, Clinica newEntity) {
            Clinica soughtClinic = ctx.Clinicas.Find(id);

            if(soughtClinic != null) {
                // UNDONE: soughtClinic != null
            }

            ctx.Clinicas.Update(soughtClinic);
            ctx.SaveChanges();
        }
    }
}
