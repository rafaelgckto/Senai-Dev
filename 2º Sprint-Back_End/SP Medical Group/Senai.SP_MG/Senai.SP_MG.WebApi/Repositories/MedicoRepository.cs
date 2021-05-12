using Senai.SP_MG.WebApi.Contexts;
using Senai.SP_MG.WebApi.Domain;
using Senai.SP_MG.WebApi.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SP_MG.WebApi.Repositories {
    public class MedicoRepository : IStantardRepository<Medico> {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Medicos.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Medico> ListAll() {
            return ctx.Medicos.ToList();
        }

        public void Register(Medico newEntity) {
            ctx.Medicos.Add(newEntity);
            ctx.SaveChanges();
        }

        public Medico SearchById(int id) {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void Update(int id, Medico newEntity) {
            Medico doctorSought = ctx.Medicos.Find(id);

            if(doctorSought != null) {
                // UNDONE: doctorSought != null
            }

            ctx.Medicos.Update(doctorSought);
            ctx.SaveChanges();
        }
    }
}
