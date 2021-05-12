using System.Collections.Generic;

namespace Senai.SP_MG.WebApi.Interfaces.Repositories.Base {
    interface IStantardRepository<TEntity> {
        List<TEntity> ListAll();
        TEntity SearchById(int id);
        void Register(TEntity newEntity);
        void Update(int id, TEntity newEntity);
        void Delete(int id);
    }
}
