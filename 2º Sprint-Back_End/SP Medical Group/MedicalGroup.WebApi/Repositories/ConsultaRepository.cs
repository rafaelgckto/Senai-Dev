using Microsoft.EntityFrameworkCore;
using MedicalGroup.WebApi.Contexts;
using MedicalGroup.WebApi.Domains;
using MedicalGroup.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MedicalGroup.WebApi.Repositories {
    public class ConsultaRepository : IConsultaRepository {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Consulta.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Consulta> ListAll() {
            return ctx.Consulta
                .Include(m => m.IdMedicoNavigation)
                .Include(m => m.IdMedicoNavigation.IdEspecialidadeNavigation)
                .Include(p => p.IdPacienteNavigation)
                .Include(s => s.IdSituacaoNavigation)
                .ToList();
        }

        public List<Consulta> ListMedico(string name) {
            return ctx.Consulta
            .Include(m => m.IdMedicoNavigation)
            .Include(m => m.IdMedicoNavigation.IdEspecialidadeNavigation)
            .Include(m => m.IdMedicoNavigation.IdUsuarioNavigation)
            .Include(p => p.IdPacienteNavigation)
            .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)
            .Include(s => s.IdSituacaoNavigation)
            .Where(m => m.IdMedicoNavigation.Nome == name)
            .ToList();
        }

        public List<Consulta> ListPaciente(string name) {
            return ctx.Consulta
            .Include(m => m.IdMedicoNavigation)
            .Include(m => m.IdMedicoNavigation.IdEspecialidadeNavigation)
            .Include(m => m.IdMedicoNavigation.IdUsuarioNavigation)
            .Include(p => p.IdPacienteNavigation)
            .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)
            .Include(s => s.IdSituacaoNavigation)
            .Where(p => p.IdPacienteNavigation.Nome == name)
            .ToList();
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

            if(newEntity != null) {
                // UNDONE: newEntity.<atributo> != null
                fetchedQuery = newEntity;
            }

            ctx.Consulta.Update(fetchedQuery);
            ctx.SaveChanges();
        }
    }
}
