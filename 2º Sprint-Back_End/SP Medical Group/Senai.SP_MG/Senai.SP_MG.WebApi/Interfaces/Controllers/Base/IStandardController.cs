using Microsoft.AspNetCore.Mvc;

namespace Senai.SP_MG.WebApi.Interfaces.Controllers.Base {
    interface IStandardController<TEntity> {
        IActionResult Get();
        IActionResult Get(int id);
        IActionResult Post(TEntity newEntity);
        IActionResult Put(int id, TEntity newEntity);
        IActionResult Delete(int id);
    }
}
