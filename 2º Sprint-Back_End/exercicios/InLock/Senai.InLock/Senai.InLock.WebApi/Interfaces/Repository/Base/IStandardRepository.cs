using System.Collections.Generic;

namespace Senai.InLock.WebApi.Interfaces {
    interface IStandardRepository<TEntity> {
        List<TEntity> ListAll();
        TEntity SearchById(int id);
        void Register(TEntity newTEntity);
        void Update(TEntity newTEntity);
        void Delete(int id);
    }
}
