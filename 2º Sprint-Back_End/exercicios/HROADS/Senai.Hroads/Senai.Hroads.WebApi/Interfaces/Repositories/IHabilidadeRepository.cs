using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace Senai.Hroads.WebApi.Interfaces.Repositories {
    interface IHabilidadeRepository : IStandardRepository<Habilidade> {
        Habilidade AmountSkills();
        List<Habilidade> AscendingOrderById();
        List<Habilidade> ListSkillsAndTypes();
    }
}
