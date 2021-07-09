using System.Collections.Generic;
using MedicalGroup.WebApi.Domains;
using MedicalGroup.WebApi.Interfaces.Repositories.Base;

namespace MedicalGroup.WebApi.Interfaces.Repositories {
    interface IConsultaRepository : IStantardRepository<Consulta> {
        List<Consulta> ListMedico(string name);
        List<Consulta> ListPaciente(string name);
    }
}