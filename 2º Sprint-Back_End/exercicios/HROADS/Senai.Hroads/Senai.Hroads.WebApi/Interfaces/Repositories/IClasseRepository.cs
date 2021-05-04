using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace Senai.Hroads.WebApi.Interfaces.Repositories {
    interface IClasseRepository : IStandardRepository<Classe> {
        List<Classe> ListNames();
    }
}
