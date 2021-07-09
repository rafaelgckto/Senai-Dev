using System.Collections.Generic;

namespace MedicalGroup.WebApi.Interfaces.Repositories.Base {
    interface IStantardRepository<TEntity> {
        List<TEntity> ListAll();
        TEntity SearchById(int id);
        void Register(TEntity newEntity);
        void Update(int id, TEntity newEntity);
        void Delete(int id);
    }
}
