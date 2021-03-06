using MedicalGroup.WebApi.Contexts;
using MedicalGroup.WebApi.Domains;
using MedicalGroup.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace MedicalGroup.WebApi.Repositories {
    public class PacienteRepository : IStantardRepository<Paciente> {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Pacientes.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Paciente> ListAll() {
            return ctx.Pacientes.ToList();
        }

        public void Register(Paciente newEntity) {
            ctx.Pacientes.Add(newEntity);
            ctx.SaveChanges();
        }

        public Paciente SearchById(int id) {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Update(int id, Paciente newEntity) {
            Paciente soughtPatient = ctx.Pacientes.Find(id);

            if(soughtPatient != null) {
                // UNDONE: soughtPatient != null
            }

            ctx.Pacientes.Update(soughtPatient);
            ctx.SaveChanges();
        }
    }
}
