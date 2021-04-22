using Senai.InLock.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Interfaces {
    interface IJogosRepository : IStandardRepository<JogosDomain> {
        List<JogosDomain> ListGamesStudios();
        List<JogosDomain> ListStudiosGames();
    }
}
