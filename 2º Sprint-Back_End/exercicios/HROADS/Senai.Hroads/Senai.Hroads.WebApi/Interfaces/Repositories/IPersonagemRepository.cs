using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace Senai.Hroads.WebApi.Interfaces.Repositories {
    interface IPersonagemRepository : IStandardRepository<Personagem> {
        List<Personagem> ListCorresponding();
        List<Personagem> ListNotCorresponding();
    }
}
