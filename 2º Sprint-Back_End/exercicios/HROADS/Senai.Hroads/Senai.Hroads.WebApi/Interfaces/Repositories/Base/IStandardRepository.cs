using System.Collections.Generic;

namespace Senai.Hroads.WebApi.Interfaces.Repositories.Base {
    interface IStandardRepository<TEntity> {
        List<TEntity> ListAll();
        TEntity SearchById(int id);
        void Register(TEntity newEntity);
        void Update(int id, TEntity newEntity);
        void Delete(int id);
    }
}
